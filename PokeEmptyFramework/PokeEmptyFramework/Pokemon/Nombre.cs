/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 22:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Nombre.
	/// </summary>
	public class Nombre
	{
			string nombre;

		public string Text {
			get {
				return nombre;
			}
			set {
				
				if(string.IsNullOrEmpty(value))
					throw new ArgumentException("Debe de tener un valor");
				
				nombre = char.ToUpper(value[0])+(value.Length>1?value.Substring(1).ToLower():"");
			}
		}

		public string VarProject
		{
			get{
			//lo pongo como quieren ponerlo
			return "SPECIES_"+Text.ToUpper();

			}
		}
	

	}
}
