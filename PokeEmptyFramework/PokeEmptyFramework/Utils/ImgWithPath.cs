/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 20:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of ImgWithPath.
	/// </summary>
	public class ImgWithPath
	{
		public const string EXTENSION=".png";
		
		FileInfo path;
		Bitmap img;
		
		public ImgWithPath(Bitmap bmpEmpty=null,FileInfo path=null)
		{
			Img=bmpEmpty;
			Path=path;
		}

		public Bitmap Img {
			get {
				return img;
			}
			set{
				img=value;
			}
		}

		public FileInfo Path {
			get {
				return path;
			}
			set{
				if(value!=null&&value.Extension!=EXTENSION)
					value=new FileInfo(value.FullName+EXTENSION);
					
				path=value;
			}
		}
		public void Load()
		{
			if(path==null||!path.Exists)
				throw new FileNotFoundException();
			Img=new Bitmap(Path.FullName);
		}
		public void Save()
		{
			if(path==null)
				throw new Exception("Falta una ruta");
			
			Img.Save(Path.FullName,ImageFormat.Png);
		}
	}
}
