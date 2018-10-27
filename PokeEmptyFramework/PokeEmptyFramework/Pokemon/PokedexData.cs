/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 13/10/2018
 * Hora: 1:34
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of PokedexData.
	/// </summary>
	public class PokedexData
	{
		string categoria;
		int peso;
		int altura;
		string descripcion1;
		string descripcion2;
		int escalaPokemon;
		int offsetPokemon;
		int escalaEntrenador;
		int offsetEntrenador;

		public string Categoria {
			get {
				return categoria;
			}
			set {
				categoria = value;
			}
		}
		public int Peso {
			get {
				return peso;
			}
			set {
				peso = value;
			}
		}

		public int Altura {
			get {
				return altura;
			}
			set {
				altura = value;
			}
		}

		public string Descripcion1 {
			get {
				return descripcion1;
			}
			set {
				descripcion1 = value;
			}
		}

		public string Descripcion2 {
			get {
				return descripcion2;
			}
			set {
				descripcion2 = value;
			}
		}

		public int EscalaPokemon {
			get {
				return escalaPokemon;
			}
			set {
				escalaPokemon = value;
			}
		}
        //no se que es esto...
		public int OffsetPokemon {
			get {
				return offsetPokemon;
			}
			set {
				offsetPokemon = value;
			}
		}

		public int EscalaEntrenador {
			get {
				return escalaEntrenador;
			}
			set {
				escalaEntrenador = value;
			}
		}
        //no se que es esto...
        public int OffsetEntrenador {
			get {
				return offsetEntrenador;
			}
			set {
				offsetEntrenador = value;
			}
		}
		

	}
}
