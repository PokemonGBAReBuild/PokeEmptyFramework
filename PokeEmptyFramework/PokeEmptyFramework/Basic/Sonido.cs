/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 08/10/2018
 * Hora: 5:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Sonido.
	/// </summary>
	public class Sonido
	{
		FileInfo path;
		
		public FileInfo Path {
			get {
				return path;
			}
			set {
				path = value;
			}
		}
	}
}
