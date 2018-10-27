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

namespace PokemonEmptyFramework.Import.Pokeruby.Pokemon
{
	/// <summary>
	/// Description of Nombre.
	/// </summary>
	public static class Nombre
	{
		static readonly StartOnTheNextLine START=(line)=>true;
		static readonly EndElementOnTheNextLine END=(line)=>line.Contains(",");
		public static string Path=System.IO.Path.Combine("src","data","text","species_names_en.h");
		
		public static void Load(DirectoryInfo dirProject,Frame.Pokemon pokemon)
		{
			pokemon.Nombre.Text=GetName(TextFile.GetStringLine(dirProject,Path,START,pokemon.Orden.Nacional));
		}
		

		static string GetName(string dirtyName)
		{
			return dirtyName.Split('=')[1].Trim('_','(',')','\"',',',' ');
		}

		public static void Load(DirectoryInfo dirProject,IList<Frame.Pokemon> pokedex)
		{
			IList<string> dirtyNames=TextFile.GetStringLines(dirProject,Path,START,0,END);
			for(int i=0;i<pokedex.Count;i++)
				pokedex[i].Nombre.Text=GetName(dirtyNames[i]);
		}
	}
}
