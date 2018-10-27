/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 20/10/2018
 * Hora: 23:19
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
	/// Description of Orden.
	/// </summary>
	public static class Orden
	{
		public static string PathOrdenes=Path.Combine("src","data","pokedex_orders.h");//Alfabetical,Weight,Height
		public static string PathNacionalYLocal=Path.Combine("include","constants","species.h");
		


		public static List<Frame.Pokemon> Load(DirectoryInfo dirProject)
		{
			SortedList<string,Frame.Pokemon> lstPokedex=new SortedList<string,Frame.Pokemon>();
            throw new NotImplementedException();
		}
	}
}
