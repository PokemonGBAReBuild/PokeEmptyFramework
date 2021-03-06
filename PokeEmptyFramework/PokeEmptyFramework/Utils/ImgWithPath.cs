﻿/*
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
using PokemonGBAFrameWork;

namespace PokemonEmptyFramework
{
    /// <summary>
    /// Description of ImgWithPath.
    /// </summary>
    public class ImgWithPath
    {
        public const string EXTENSION = ".png";

        DirectoryInfo pathDir;
        string fileName;
        Bitmap img;

        public ImgWithPath(Bitmap bmpEmpty = null):this(new FileInfo(""), bmpEmpty)
        {
        }
            public ImgWithPath(FileInfo path, Bitmap bmpEmpty = null)
        {
            Img = bmpEmpty;
            Path = path == null ? new FileInfo("") : path;
        }

        public ImgWithPath(string nombre , Bitmap bmpEmpty = null) : this(new FileInfo(""), bmpEmpty)
        {
            this.fileName = nombre;
        }

        public Bitmap Img
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }

        public FileInfo Path
        {
            get
            {
                return new FileInfo(System.IO.Path.Combine(PathDir.FullName, FileName));
            }
            set
            {
                if (value!=null&&!string.IsNullOrEmpty(value.FullName))
                {
                    if (value.Extension != EXTENSION)
                        value = new FileInfo(value.FullName + EXTENSION);

                    PathDir = new DirectoryInfo(System.IO.Path.GetDirectoryName(value.FullName));
                    FileName = System.IO.Path.GetFileName(value.FullName);
                }
            }
        }

        public bool NoTienePathValido => PathDir == null && string.IsNullOrEmpty(FileName);

        public DirectoryInfo PathDir { get => pathDir; set => pathDir = value; }
        public string FileName { get => fileName; set => fileName = value; }

        public void Load()
        {
            if (NoTienePathValido || !Path.Exists)
                throw new FileNotFoundException();
            Img = new Bitmap(Path.FullName);
        }
        public void Save()
        {
            if (NoTienePathValido)
                throw new Exception("Falta una ruta");

            Img.Save(Path.FullName, ImageFormat.Png);
        }
    }
}
