/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 07/10/2018
 * Hora: 22:50
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonEmptyFramework
{
	public delegate bool StartOnTheNextLine(string line);
	public delegate bool EndElementOnTheNextLine(string line);
	/// <summary>
	/// Es una clase para leer/escribir facilmente archivos de texto
	/// </summary>
	public static class TextFile
	{
		public static string GetStringLine(DirectoryInfo dirProject,string pathFile,StartOnTheNextLine startLine,int pos,bool omitirLineasEmpty=false)
		{
			return GetStringLines(dirProject,pathFile,startLine,pos,(line)=>true,omitirLineasEmpty)[0];
		}
		public static List<string> GetStringLines(DirectoryInfo dirProject,string pathFile,StartOnTheNextLine startLine,int pos,EndElementOnTheNextLine endElement,bool omitirLineasEmpty=false)
		{
			StreamReader sr=new StreamReader(Path.Combine(dirProject.FullName,pathFile));
			string aux;
			List<string> lineas=new List<string>();
			try{
				do
				{
					aux=sr.ReadLine();
					
				}
				while((omitirLineasEmpty&&string.IsNullOrEmpty(aux)||!startLine(aux))&&!sr.EndOfStream);
				
				for(int i=0;i<pos&&!sr.EndOfStream;i++)
				{
					do
					{
						aux=sr.ReadLine();
						
					}
					while((omitirLineasEmpty&&string.IsNullOrEmpty(aux)||!endElement(aux))&&!sr.EndOfStream);
					
				}
				if(!sr.EndOfStream){
					do{
						aux=sr.ReadLine();
						if(!omitirLineasEmpty||!string.IsNullOrEmpty(aux))
							lineas.Add(aux);
					}
					while((omitirLineasEmpty&&string.IsNullOrEmpty(aux)||!endElement(lineas[lineas.Count-1]))&&!sr.EndOfStream);
				}
			}finally{
				sr.Close();
			}
			return lineas;
		}
		public static void SetStringLine(DirectoryInfo dirProject,string pathFile,StartOnTheNextLine startLine,int pos,string linea,bool sustituirElemento=true)
		{
			SetStringLines(dirProject,pathFile,startLine,pos,(line)=>true,new string[]{linea},sustituirElemento);
		}
		public static void SetStringLines(DirectoryInfo dirProject,string pathFile,StartOnTheNextLine startLine,int pos,EndElementOnTheNextLine endElement,IList<string> lineas,bool sustituirElemento=true)
		{
			string path=Path.Combine(dirProject.FullName,pathFile);
			string tempPath=Path.GetRandomFileName();
			string lineaAux;
			bool isStartLine;
			StreamReader sr=new StreamReader(path);
			StreamWriter sw=new StreamWriter(tempPath);
			
			try{
				do{
					lineaAux=sr.ReadLine();
					isStartLine=startLine(lineaAux);
					sw.WriteLine(lineaAux);
				}
				while(!isStartLine&&!sr.EndOfStream);
				
				for(int i=0;i<pos&&!sr.EndOfStream;i++)
				{
					
					do{
						lineaAux=sr.ReadLine();
						sw.WriteLine(lineaAux);
					}
					while(!endElement(lineaAux)&&!sr.EndOfStream);
					
				}
				
				
				for(int i=0;i<lineas.Count;i++)
					sw.WriteLine(lineas[i]);
				
				if(sustituirElemento)
				{
					while(!endElement(sr.ReadLine())&&!sr.EndOfStream);
				}
				//pongo el resto del documento
				while(!sr.EndOfStream)
					sw.WriteLine(sr.ReadLine());
			}finally{
				sr.Close();
				sw.Close();
				File.Delete(path);
				File.Move(tempPath,path);
			}

		}
	}
}
