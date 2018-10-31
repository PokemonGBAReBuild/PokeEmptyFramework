/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.IO;
using PokemonGBAFrameWork;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Paleta.
	/// </summary>
	public class Paleta
	{
		public const int LENGTH=16;


		Color[] colores;
		
		public Paleta()
		{
			colores=new Color[LENGTH];
		}

        public Paleta(Color[] paleta):this()
        {
            for (int i = 0; i < LENGTH; i++)
                colores[i] = paleta[i];
        }

        public Color[] Colores {
			get {
				return colores;
			}
			set {
				if(value==null||value.Length!=LENGTH)
					throw new Exception("Paleta incorrecta");
				colores = value;
			}
		}


		
	

	}
}
