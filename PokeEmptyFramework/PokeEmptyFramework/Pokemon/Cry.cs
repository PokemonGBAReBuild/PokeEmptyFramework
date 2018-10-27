/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 08/10/2018
 * Hora: 5:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
namespace PokemonEmptyFramework
{//A .wav file converted into a Signed 8bit PCM .aiff file renamed into a .aif
	/// <summary>
	/// Description of Cry.
	/// </summary>
	public class Cry
	{

		Sonido sonido;

		public Cry()
		{
			sonido=new Sonido();
		}
		public Sonido Sonido{
			get {
				return sonido;
			}
			set {
				sonido = value;
			}
		}

	}
}
