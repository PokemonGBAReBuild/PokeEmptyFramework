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
            //tener en cuenta que los tipos complejos se cargan después que sus partes...sino dará error...
            Pokemon.Tipo.Load(proyecto, romGba);
            Batalla.Item.Load(proyecto, romGba);
            Batalla.Ataque.Load(proyecto, romGba);
          
            Pokemon.Habilidad.Load(proyecto, romGba);

            Pokemon.Pokemon.Load(proyecto, romGba);

            return proyecto;
        }
    }
}
