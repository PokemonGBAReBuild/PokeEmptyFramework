/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 14/10/2018
 * Hora: 20:08
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Frame=PokemonEmptyFramework;

namespace PokemonEmptyFramework.Export.PokeEmpty.Pokemon
{
	/// <summary>
	/// Description of Nombre.
	/// </summary>
	public static class Nombre
	{
		static readonly StartOnTheNextLine START=(line)=>true;
		static readonly EndElementOnTheNextLine END=(line)=>line.Contains(",");
		public static string Path=System.IO.Path.Combine("src","data","text","species_names_en.h");
		

		public static void Save(DirectoryInfo dirProject,Frame.Pokemon pokemon,bool sustituir=true)
		{
			
			TextFile.SetStringLine(dirProject,Path,(line)=>true,pokemon.Orden.Nacional,GetName(pokemon),sustituir);
			
		}
		static string GetName(Frame.Pokemon pokemon)
		{
			StringBuilder str=new StringBuilder();
			
			//lo pongo como quieren ponerlo
			str.Append("[");
			str.Append(pokemon.Nombre.VarProject);
			str.Append("] = _(\"");
			str.Append(pokemon.Nombre.Text.ToUpper());
			str.Append("\"),");
			return str.ToString();
		}

		public static void Save(DirectoryInfo dirProject,IList<Frame.Pokemon> pokedex)
		{
			string[] names=new string[pokedex.Count];
			for(int i=0;i<pokedex.Count;i++)
				names[i]=GetName(pokedex[i]);
		
			TextFile.SetStringLines(dirProject,Path,START,0,END,names);
		}

	}
}
