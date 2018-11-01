/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 06/10/2018
 * Hora: 20:51
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using IO=System.IO;

namespace PokemonEmptyFramework
{
	/// <summary>
	/// Description of Imagenes.
	/// </summary>
	public class Imagenes
	{
        public class Coordenadas
        {
            //mirar como va
        }

        const int FRONTBACKLADO=64;
		const int ICONLADO=32;
		const int FOOTPRINTLADO=16;
		
		List<ImgWithPath> imgsBack;
		List<ImgWithPath> imgsFront;
		List<Paleta> paletasNormal;
		List<Paleta> paletasShiny;
		
		//de momento de esto solo hay una opción por pokemon :)
		ImgWithPath imgIcon;
		ImgWithPath imgFootPrint;


        Coordenadas coordenadasFront;
        Coordenadas coordenadasBack;

		public Imagenes(bool initialitze=true)
		{
			
			imgsBack=new List<ImgWithPath>(new ImgWithPath[] { new ImgWithPath(!initialitze ? null : new System.Drawing.Bitmap(FRONTBACKLADO, FRONTBACKLADO)) });
			imgsFront=new  List<ImgWithPath>(new ImgWithPath[] { new ImgWithPath(!initialitze ? null : new System.Drawing.Bitmap(FRONTBACKLADO, FRONTBACKLADO)) });
			imgIcon=new ImgWithPath( !initialitze ? null : new System.Drawing.Bitmap(ICONLADO, ICONLADO * 2) );
			imgFootPrint=new ImgWithPath( !initialitze ? null : new System.Drawing.Bitmap(FOOTPRINTLADO, FOOTPRINTLADO) );
			
			paletasNormal=new  List<Paleta>(new Paleta[] { new Paleta() });
			paletasShiny=new  List<Paleta>(new Paleta[] { new Paleta() });
		}

		public ImgWithPath ImgBack {
			get {
				return imgsBack[0];
			}
            set
            {
                if (imgsBack.Count > 0)
                    imgsBack[0] = value;
                else imgsBack.Add(value);
;            }
		}

		public ImgWithPath ImgFront {
			get {
				return imgsFront[0];
			}
            set
            {
                if (imgsFront.Count > 0)
                    imgsFront[0] = value;
                else imgsFront.Add(value);
            }
        }

		public ImgWithPath ImgIcon {
			get {
				return imgIcon;
			}
            set
            {
                imgIcon = value;
            }
		}

		public ImgWithPath ImgFootPrint {
			get {
				return imgFootPrint;
			}
            set
            {
                imgFootPrint = value;
            }
		}

		public Paleta PaletaNormal {
			get {
				return paletasNormal[0];
			}set{
				paletasNormal[0]=value;
			}
		}

		public Paleta PaletaShiny {
			get {
				return paletasShiny[0];
			}
			set{
				paletasShiny[0]=value;
			}
		}

		public List<ImgWithPath> ImgsBack {
			get {
				return imgsBack;
			}
		}

		public List<ImgWithPath> ImgsFront {
			get {
				return imgsFront;
			}
		}

		public List<Paleta> PaletasNormal {
			get {
				return paletasNormal;
			}
		}

		public List<Paleta> PaletasShiny {
			get {
				return paletasShiny;
			}
		}

        public Coordenadas CoordenadasFront { get => coordenadasFront; set => coordenadasFront = value; }
        public Coordenadas CoordenadasBack { get => coordenadasBack; set => coordenadasBack = value; }

        /// <summary>
        /// Solo actualiza los archivos eso quiere decir que los que no esten creados no los pone
        /// </summary>
        public void UpdateFiles()
		{
			IList<ImgWithPath>[] lsts={ImgsBack,ImgsFront,new ImgWithPath[]{ImgIcon,ImgFootPrint}};
			
			for(int j=0;j<lsts.Length;j++)
				for(int i=0;i<lsts[j].Count;i++)
				if(lsts[j][i].Path!=null&&lsts[j][i].Path.Exists)
					lsts[j][i].Save();
		}


    }
}
