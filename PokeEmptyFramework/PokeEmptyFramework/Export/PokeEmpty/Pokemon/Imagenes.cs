/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 14/10/2018
 * Hora: 18:18
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Text;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Export.PokeEmpty.Pokemon
{
    /// <summary>
    /// Description of Imagenes.
    /// </summary>
    public static class Imagenes
    {
        public static string ExtensionMultiforma = "mk";
        //ruta proyecto pokeruby
        public static string Ruta = Path.Combine("grafics", "pokemon");

        public static void CopyToDir(DirectoryInfo dirProject, Frame.Pokemon pokemon)
        {
            string pathDirDestino = Path.Combine(dirProject.FullName, Ruta, pokemon.Nombre.Text);

            if (!Directory.Exists(pathDirDestino))
                Directory.CreateDirectory(pathDirDestino);

            pokemon.Imagenes.UpdateFiles();

            if (IsSingelPic(dirProject, pokemon))
            {
                if (File.Exists(pokemon.Imagenes.ImgBack.Path.FullName))
                    File.Copy(pokemon.Imagenes.ImgBack.Path.FullName, Path.Combine(pathDirDestino, "back.png"));
                else
                {
                    pokemon.Imagenes.ImgBack.Path = new FileInfo(Path.Combine(pathDirDestino, "back.png"));
                    pokemon.Imagenes.ImgBack.Save();
                }

                if (File.Exists(pokemon.Imagenes.ImgFront.Path.FullName))
                    File.Copy(pokemon.Imagenes.ImgFront.Path.FullName, Path.Combine(pathDirDestino, "front.png"));
                else
                {
                    pokemon.Imagenes.ImgFront.Path = new FileInfo(Path.Combine(pathDirDestino, "front.png"));
                    pokemon.Imagenes.ImgFront.Save();
                }


                Basic.Paleta.Save(dirProject, Ruta, "normal", pokemon.Imagenes.PaletaNormal);
                Basic.Paleta.Save(dirProject, Ruta, "shiny", pokemon.Imagenes.PaletaShiny);

            }
            else
            {
                //se ponen con un nombre diferente 
                //podria poner front_{0},numeroImg y lo mismo con back y las paletas :)
                for (int i = 0; i < pokemon.Imagenes.ImgsFront.Count; i++)
                {
                    if (File.Exists(pokemon.Imagenes.ImgsFront[i].Path.FullName))
                        File.Copy(pokemon.Imagenes.ImgsFront[i].Path.FullName, Path.Combine(pathDirDestino, string.Format("front_{0}.png", i)));
                    else
                    {
                        pokemon.Imagenes.ImgsFront[i].Path = new FileInfo(Path.Combine(pathDirDestino, string.Format("front_{0}.png", i)));
                        pokemon.Imagenes.ImgsFront[i].Save();
                    }
                }
                for (int i = 0; i < pokemon.Imagenes.ImgsBack.Count; i++)
                {
                    if (File.Exists(pokemon.Imagenes.ImgsBack[i].Path.FullName))
                        File.Copy(pokemon.Imagenes.ImgsBack[i].Path.FullName, Path.Combine(pathDirDestino, string.Format("back_{0}.png", i)));
                    else
                    {
                        pokemon.Imagenes.ImgsBack[i].Path = new FileInfo(Path.Combine(pathDirDestino, string.Format("back_{0}.png", i)));
                        pokemon.Imagenes.ImgsBack[i].Save();
                    }
                }
                for (int i = 0; i < pokemon.Imagenes.PaletasNormal.Count; i++)
                    Basic.Paleta.Save(dirProject, Ruta, string.Format("normal_{0}", i), pokemon.Imagenes.PaletasNormal[i]);
                for (int i = 0; i < pokemon.Imagenes.PaletasShiny.Count; i++)
                    Basic.Paleta.Save(dirProject, Ruta, string.Format("shiny_{0}", i), pokemon.Imagenes.PaletasShiny[i]);

            }
            //parte común
            if (File.Exists(pokemon.Imagenes.ImgIcon.Path.FullName))
                File.Copy(pokemon.Imagenes.ImgIcon.Path.FullName, Path.Combine(pathDirDestino, "icon.png"));
            else
            {
                pokemon.Imagenes.ImgIcon.Path = new FileInfo(Path.Combine(pathDirDestino, "icon.png"));
                pokemon.Imagenes.ImgIcon.Save();
            }
            if (File.Exists(pokemon.Imagenes.ImgFootPrint.Path.FullName))
                File.Copy(pokemon.Imagenes.ImgFootPrint.Path.FullName, Path.Combine(pathDirDestino, "footprint.png"));
            else
            {
                pokemon.Imagenes.ImgFootPrint.Path = new FileInfo(Path.Combine(pathDirDestino, "footprint.png"));
                pokemon.Imagenes.ImgFootPrint.Save();
            }

        }

        static bool IsSingelPic(DirectoryInfo dirProject, Frame.Pokemon pokemon)
        {
            return File.Exists(Path.Combine(dirProject.FullName, Ruta, pokemon.Nombre.Text, "back.png"));
        }

        public static void Save(DirectoryInfo dirProject, Frame.Pokemon pokemon)
        {
            const int SINGLEFORM = 1;
            const int PARTES = 4;
            string pathDirDestino = Path.Combine(dirProject.FullName, Ruta, pokemon.Nombre.Text);
            string pathMultiForma;
            string varDirPokemonMultiforma;
            string[] campos = { ".4bpp", "4bpp", ".gbapal", ".gbapal", "back", "front", "normal", "shiny" };
            StringBuilder sbMultiForma;
            if (!Directory.Exists(pathDirDestino))
                Directory.CreateDirectory(pathDirDestino);

            //guardo los archivos
            CopyToDir(dirProject, pokemon);



            if (pokemon.Imagenes.ImgsBack.Count != SINGLEFORM)
            {
                //es como castform tiene más de una imagen castform.mk hacer archivo como el de castform y añadirlo despues en el MakeFile

                pathMultiForma = Path.Combine(dirProject.FullName, string.Format("{0}.{1}", pokemon.Nombre.Text, ExtensionMultiforma));
                varDirPokemonMultiforma = pokemon.Nombre.ToString().ToUpper() + "GFXDIR";

                if (File.Exists(pathMultiForma))
                    File.Delete(pathMultiForma);
                sbMultiForma = new StringBuilder();
                //hago el archivo

                //solo falta mirar como programar la forma genérica de momento solo hacer como castform...luego ya se hará el resto :)
                //hace archivo para la compilación
                sbMultiForma.AppendLine(string.Format("{0} := {1}/{2}", varDirPokemonMultiforma, Ruta,pokemon.Nombre.ToString().ToLower()));
                for (int j = 0; j < PARTES; j++)
                {
                    sbMultiForma.AppendLine();
                    sbMultiForma.AppendLine(string.Format("$({0})/{1}.{2}: $({0})/{1}_0.{2}\\", varDirPokemonMultiforma,  campos[j + PARTES], campos[j]));
                    for (int i = 1; i < pokemon.Imagenes.ImgsBack.Count; i++)
                    {
                        sbMultiForma.AppendLine(string.Format("                             $({0})/{1}.{2} \\", varDirPokemonMultiforma, string.Format("{1}_{0}", i, campos[j + PARTES]), campos[j]));
                    }
                    sbMultiForma.Append("	@cat");
                    for (int i = 0; i < pokemon.Imagenes.ImgsBack.Count; i++)
                    {
                        sbMultiForma.AppendLine(string.Format(" $({0})/{1}.{2} \\", varDirPokemonMultiforma, string.Format("{1}_{0}", i, campos[j + PARTES]), campos[j]));
                    }
                    sbMultiForma.AppendLine(" >$@");
                    sbMultiForma.AppendLine();
                }
                sbMultiForma.Replace('/', Path.AltDirectorySeparatorChar);//en linux los directorios van diferentes de alli esto :)
                File.WriteAllText(pathMultiForma, sbMultiForma.ToString());
                //añadir en el makefile
                //añado el include
                TextFile.SetStringLine(dirProject, "Makefile", (line) => line.Contains("GFX_OPTS :="), 1, string.Format("include {0}.{1}", pokemon.Nombre.Text.ToLower(), ExtensionMultiforma), false);
            }

        }

      
    }
}
