/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 14/10/2018
 * Hora: 18:05
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using Frame = PokemonEmptyFramework; 
namespace PokemonEmptyFramework.Export.PokeEmpty.Basic
{
	/// <summary>
	/// Description of Paleta.
	/// </summary>
	public static class Paleta
	{
		public const string EXTENSION=".pal";

		public static readonly byte[] SEPARADOR =new byte[] {0x0D, 0x0A};

		static readonly byte[] HEADERP1=new byte[] {0x4A, 0x41, 0x53, 0x43, 0x2D, 0x50, 0x41, 0x4C };
		
		static readonly byte[] HEADERP2=new byte[] {	0x30, 0x31, 0x30, 0x30};
		static readonly byte[] HEADERP3=new byte[] {	0x31, 0x36};

		public static void Save(DirectoryInfo dirProject,string pathCarpeta,string archivoPaleta,Frame.Paleta paleta)
		{
			Save(Path.Combine(dirProject.FullName,pathCarpeta),archivoPaleta,paleta);
		}
		public static void Save(string fullPathCarpeta,string archivoPaleta,Frame.Paleta paleta)
		{
			if(!archivoPaleta.EndsWith(EXTENSION))
				archivoPaleta=archivoPaleta+EXTENSION;
			
			BinaryWriter bw=new BinaryWriter(new FileStream(Path.Combine(fullPathCarpeta,archivoPaleta),FileMode.Create,FileAccess.Write));
			
			try{
				//pongo el header
				bw.Write(HEADERP1);
				bw.Write(SEPARADOR);
				bw.Write(HEADERP2);
				bw.Write(SEPARADOR);
				bw.Write(HEADERP3);
				bw.Write(SEPARADOR);
				
				for(int i=0;i<paleta.Colores.Length;i++)
				{
					//RGB?
					bw.Write(paleta.Colores[i].R);
					bw.Write(paleta.Colores[i].G);
					bw.Write(paleta.Colores[i].B);
					
					bw.Write(SEPARADOR);
				}
			}finally{
				bw.Close();
			}
		}
	}
}
