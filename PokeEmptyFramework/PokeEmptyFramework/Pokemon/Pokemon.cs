﻿/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 20:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using Gabriel.Cat.S.Utilitats;
namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Pokemon.
	/// </summary>
	public class Pokemon:IComparable<Pokemon>
	{
		public enum OrdenarPor{
			Nombre,
			Peso,
			Altura,
			OrdenNacional,
			OrdenLocal
		}
		
		public static OrdenarPor OrdenSort=OrdenarPor.OrdenNacional;
		
		public Orden Orden{get;set;}
		public Nombre Nombre{get;  set;}
		public Imagenes Imagenes{get;set;}
		public PokedexData PokedexData{get;set;}
		public Cry Cry{get;  set;}
		public AtaquesAprendidos AtaquesAprendidos { get;  set; }
        public MTMOCompatibles MTMOCompatibles { get;  set; }
        public Evoluciones Evoluciones { get;  set; }
        public StatsBase Stats { get; set; }

		public Pokemon()
		{
            Orden = new Orden();
            Nombre =new Nombre();
            PokedexData = new PokedexData();
			Cry=new Cry();
			Imagenes=new Imagenes();
            MTMOCompatibles = new MTMOCompatibles();
            AtaquesAprendidos = new AtaquesAprendidos();
            Evoluciones = new Evoluciones();
            Stats = new StatsBase();
		}
		
		#region IComparable implementation
		int IComparable<Pokemon>.CompareTo(Pokemon other)
		{
			int compareTo=other==null?(int)CompareTo.Inferior:(int)CompareTo.Iguals;
			if (compareTo == (int)CompareTo.Iguals)
				switch (OrdenSort) {
				case OrdenarPor.Nombre:
						compareTo = string.Compare(Nombre.Text, other.Nombre.Text, StringComparison.Ordinal);
					break;
				case OrdenarPor.Peso:
					compareTo=PokedexData.Peso.CompareTo(other.PokedexData.Peso);
					break;
				case OrdenarPor.Altura:
					compareTo=PokedexData.Altura.CompareTo(other.PokedexData.Altura);
					break;
				case OrdenarPor.OrdenNacional:
					compareTo=Orden.Nacional.CompareTo(other.Orden.Nacional);
					break;
				case OrdenarPor.OrdenLocal:
					compareTo=Orden.Local.CompareTo(other.Orden.Local);
					break;

			}
			return compareTo;
		}
		#endregion
	}
}
