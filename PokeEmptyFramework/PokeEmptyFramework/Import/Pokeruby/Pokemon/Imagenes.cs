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
using Frame=PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Pokeruby.Pokemon
{
    /// <summary>
    /// Description of Imagenes.
    /// </summary>
    public static class Imagenes
    {
        public static string ExtensionMultiforma = "mk";
        //ruta proyecto pokeruby
        public static string Ruta = Path.Combine("grafics", "pokemon");


        static bool IsSingelPic(DirectoryInfo dirProject, Frame.Pokemon pokemon)
        {
            return File.Exists(Path.Combine(dirProject.FullName, Ruta, pokemon.Nombre.Text, "back.png"));
        }


        public static void Load(DirectoryInfo dirProject, Frame.Pokemon pokemon)
        {
            string ruta = Path.Combine(dirProject.FullName, Ruta, pokemon.Nombre.Text.ToLower());

            if (IsSingelPic(dirProject, pokemon))
            {

                pokemon.Imagenes.ImgBack.Path = new FileInfo(Path.Combine(ruta, "back.png"));
                pokemon.Imagenes.ImgFront.Path = new FileInfo(Path.Combine(ruta, "front.png"));
                pokemon.Imagenes.ImgIcon.Path = new FileInfo(Path.Combine(ruta, "icon.png"));
                pokemon.Imagenes.ImgFootPrint.Path = new FileInfo(Path.Combine(ruta, "footprint.png"));

                pokemon.Imagenes.PaletaNormal = Basic.Paleta.Load(dirProject, ruta, "normal");
                pokemon.Imagenes.PaletaShiny = Basic.Paleta.Load(dirProject, ruta, "shiny");
            }
            else
            {
                //leer archivo mk
            }
        }
        internal static void LoadPokedex(DirectoryInfo dirProject, IList<Frame.Pokemon> pokedex)
        {
            for (int i = 0; i < pokedex.Count; i++)
                Load(dirProject, pokedex[i]);
        }
    }
}
