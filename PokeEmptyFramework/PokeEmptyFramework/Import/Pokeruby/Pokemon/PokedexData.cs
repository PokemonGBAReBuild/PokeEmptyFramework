/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 20/10/2018
 * Hora: 23:28
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;
using Frame=PokemonEmptyFramework;

namespace PokemonEmptyFramework.Import.Pokeruby.Pokemon
{
	/// <summary>
	/// Description of PokedexData.
	/// </summary>
	public static class PokedexData
	{
		public static string Path=System.IO.Path.Combine("src","data","pokedex_entries_en.h");
		
		public static void Load(DirectoryInfo dirProject,IList<Frame.Pokemon> pokedexOrdenNacional)
		{
			//gPokedexEntries en las paginas de la descripcion dice los nombres de las paginas :)
			//tener en cuenta que hay paginas para Ruby y otras para Zafiro
			
		}
	}
}
