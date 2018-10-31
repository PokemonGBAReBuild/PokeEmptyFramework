using System;
using System.Collections.Generic;
using System.Text;
using Gabriel.Cat.S.Utilitats;
namespace PokemonEmptyFramework
{
    public class Proyecto
    {
        //info proyecto
        public string Autor { get; set; }
        public IdUnico IdUnico { get;  set; }//se crea en el new o se carga no se puede cambiar o al menos no deberia...
        public string LocalPath { get; set; }
        //partes rom
        public List<Pokemon> Pokedex { get; private set; }
        public List<Item> Items { get; private set; }
        public List<Ataque> Ataques { get; private set; }
        public List<Habilidad> Habilidades { get; private set; }
        public List<GrupoHuevo> GrupoHuevos { get; private set; }
        public List<Tipo> Tipos { get; private set; }

        public Proyecto()
        {
            Pokedex = new List<Pokemon>();
            Items = new List<Item>();
            Ataques = new List<Ataque>();
            Habilidades = new List<Habilidad>();
            GrupoHuevos = new List<GrupoHuevo>();
            Tipos = new List<Tipo>();
            IdUnico = new IdUnico();
        }
    }
}
