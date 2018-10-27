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

namespace PokemonEmptyFramework.Export.PokeEmpty.Pokemon
{
	/// <summary>
	/// Description of Orden.
	/// </summary>
	public static class Orden
	{
		public static string PathOrdenes=Path.Combine("src","data","pokedex_orders.h");//Alfabetical,Weight,Height
		public static string PathNacionalYLocal=Path.Combine("include","constants","species.h");
		
		public static void Save(DirectoryInfo dirProject,List<Frame.Pokemon> pokedexOrdenNacional)
		{
			Frame.Pokemon.OrdenSort=Frame.Pokemon.OrdenarPor.OrdenNacional;
			Frame.Orden.UpdateValoresOrden(pokedexOrdenNacional);
			//los guardo
			//pongo la pokedex Nacional
			//tener en cuenta los unowns... species_old_unown_Letra...menos la A... 252-276 species_unown_Letra menos A...413-439 incluye ! y ?
			//National_Dex_Old_Unown_Letra...menos A... 387-411 lo mismo con Hoenn falta ? y ! y la parte de "new"
		}
		static string SpeciesString(Frame.Pokemon pokemon)
		{
			return "#define "+pokemon.Nombre.VarProject+" "+pokemon.Orden.Nacional;
			
		}
		static string NationalDexString(Frame.Pokemon pokemon)
		{
			return "#define NATIONAL_DEX_"+pokemon.Nombre.Text.ToUpper()+" "+pokemon.Orden.Nacional;
		}
		static string LocalDexString(Frame.Pokemon pokemon)
		{
			return "#define HOENN_DEX_"+pokemon.Nombre.Text.ToUpper()+" "+pokemon.Orden.Local;
		}

	}
}
