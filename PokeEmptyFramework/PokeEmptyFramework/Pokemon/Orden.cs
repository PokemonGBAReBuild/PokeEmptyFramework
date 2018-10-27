/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 22:59
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;
using Gabriel.Cat.S.Extension;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Orden.
	/// </summary>
	public class Orden
	{

		int nacional;
		int local;
		
		//la posición de estos valores no se pueden modificar por aqui
        //porque dependen de los valores que tenga cada pokemon y el lugar que está después de ordenarlos por ese parametro
		int alfabetico;
		int altura;
		int peso;
		
		public Orden()
		{
		}

		public int Local {
			get {
				return local;
			}
			set {
				local = value;
			}
		}
		public int Nacional {
			get {
				return nacional;
			}
			set {
				nacional = value;
			}
		}

		public int Alfabetico {
			get {
				return alfabetico;
			}
            internal set { alfabetico = value; }
		}

		public int Altura {
			get {
				return altura;
            }
            internal set { altura = value; }
        }

		public int Peso {
			get {
				return peso;
            }
            internal set { peso = value; }
        }



		public static void UpdateValoresOrden(List<Pokemon> pokedex,bool ponerOrdenComoEstaba=true)
		{
			
			Pokemon.OrdenarPor orden=Pokemon.OrdenSort;
			Pokemon.OrdenSort=Pokemon.OrdenarPor.Nombre;
            pokedex.Sort();
			for(int i=0;i<pokedex.Count;i++)
				pokedex[i].Orden.Alfabetico=i;
			
			Pokemon.OrdenSort=Pokemon.OrdenarPor.Peso;
			pokedex.Sort();
			for(int i=0;i<pokedex.Count;i++)
				pokedex[i].Orden.Peso=i;
			
			Pokemon.OrdenSort=Pokemon.OrdenarPor.Altura;
            pokedex.Sort();
			for(int i=0;i<pokedex.Count;i++)
				pokedex[i].Orden.Altura=i;
			
			if(ponerOrdenComoEstaba){
				Pokemon.OrdenSort=orden;
				pokedex.Sort();
			}
		}


	}
}
