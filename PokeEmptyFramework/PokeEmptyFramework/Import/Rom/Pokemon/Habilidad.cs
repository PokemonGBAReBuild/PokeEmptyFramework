using System;
using System.Collections.Generic;
using System.Text;
using PokemonGBAFrameWork;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Rom.Pokemon
{
    public static class Habilidad
    {
        public static void Load(Proyecto proyecto,RomGba rom)
        {
            HabilidadCompleta[] habilidades = HabilidadCompleta.GetHabilidades(rom);
            Frame.Habilidad habilidad;
            for(int i=0;i<habilidades.Length;i++)
            {
                habilidad = new Frame.Habilidad();
                habilidad.Nombre = habilidades[i].Nombre.Text;
                habilidad.Descripcion = habilidades[i].Descripcion.Texto;

                proyecto.Habilidades.Add(habilidad);
            }
        }
    }
}
