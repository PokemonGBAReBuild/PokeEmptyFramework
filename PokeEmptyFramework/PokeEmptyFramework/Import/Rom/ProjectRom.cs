using System;
using System.Collections.Generic;
using System.Text;
using PokemonGBAFrameWork;
namespace PokemonEmptyFramework.Import.Rom
{
    public static class Project
    {
        public static Proyecto GetProyecto(string pathRom)
        {
            RomGba romGba = new RomGba(pathRom);
            Proyecto proyecto = new Proyecto();
            //le pongo toda la info posible
            Batalla.Ataque.Load(proyecto, romGba);
            Batalla.Item.Load(proyecto, romGba);
            Pokemon.Habilidad.Load(proyecto, romGba);
            //al final de todo cargo pokemon
            Pokemon.Pokemon.Load(proyecto, romGba);

            return proyecto;
        }
    }
}
