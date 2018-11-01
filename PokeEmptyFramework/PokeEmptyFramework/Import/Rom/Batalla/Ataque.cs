using System;
using System.Collections.Generic;
using System.Text;
using Gabriel.Cat.S.Extension;
using Gabriel.Cat.S.Utilitats;
using PokemonGBAFrameWork;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Rom.Batalla
{
    public static class Ataque
    {
        public static void Load(Proyecto proyecto, RomGba rom)
        {
            PokemonGBAFrameWork.AtaqueCompleto[] ataques = PokemonGBAFrameWork.AtaqueCompleto.GetAtaques(rom);
            Frame.Ataque ataque;
            int lastItemNoAtack = -1;
            ushort combo;

            for (int i = 0; i < ataques.Length; i++)
            {
                ataque = new Frame.Ataque();
                ataque.Descripcion = ataques[i].Descripcion.Texto;
                ataque.Nombre = ataques[i].Nombre.Texto;

                ataque.Concurso1.Efecto = Serializar.ToUShort(ataques[i].Concursos.DatosConcursosHoenn.SubArray(0, 2));
                ataque.Concurso1.Categoria = Serializar.ToUShort(ataques[i].Concursos.DatosConcursosHoenn.SubArray(2, 2));
                ataque.Concurso1.ComboStarter = proyecto.Ataques[Serializar.ToUShort(ataques[i].Concursos.DatosConcursosHoenn.SubArray(4, 2))];
                for (int j = 6,fJ=j+8; j < fJ; j += 2)
                {
                    combo = Serializar.ToUShort(ataques[i].Concursos.DatosConcursosHoenn.SubArray(j, 2));
                    ataque.Concurso1.ComboMovimientos.Add(proyecto.Ataques[combo]);
                }
                ataque.Efecto1.Accuracy = ataques[i].Datos.Accuracy;
                ataque.Efecto1.BasePower = ataques[i].Datos.BasePower;
                ataque.Efecto1.Category = (Frame.Ataque.Efecto.Categoria)ataques[i].Datos.Category;
                ataque.Efecto1.Effect = ataques[i].Datos.Effect;
                ataque.Efecto1.EffectAccuracy = ataques[i].Datos.EffectAccuracy;
                ataque.Efecto1.IsAffectedByKingsRock = ataques[i].Datos.IsAffectedByKingsRock;
                ataque.Efecto1.IsAffectedByMagicCoat = ataques[i].Datos.IsAffectedByMagicCoat;
                ataque.Efecto1.IsAffectedByMirrorMove = ataques[i].Datos.IsAffectedByMirrorMove;
                ataque.Efecto1.IsAffectedByProtect = ataques[i].Datos.IsAffectedByProtect;
                ataque.Efecto1.IsAffectedBySnatch = ataques[i].Datos.IsAffectedBySnatch;
                ataque.Efecto1.MakesContact = ataques[i].Datos.MakesContact;
                ataque.Efecto1.PP = ataques[i].Datos.PP;
                ataque.Efecto1.Priority = ataques[i].Datos.Priority;
                ataque.Efecto1.Target = ataques[i].Datos.Target;
                ataque.Efecto1.Type = proyecto.Tipos[ataques[i].Datos.Type];

                ataque.Coleccion1 = Frame.Ataque.Coleccion.Sin;
             
                proyecto.Ataques.Add(ataque);
            }
            for (int i = 0; i < proyecto.Items.Count; i++)
            {
                if (proyecto.Items[i].Bolsillo == Frame.Item.BolsilloObjetos.MTMO)
                {
                    if (lastItemNoAtack < 0)
                        lastItemNoAtack = i - 1;

                    if (((EdicionPokemon)rom.Edicion).Idioma == Idioma.Español && proyecto.Items[i].Nombre.StartsWith("MT") || ((EdicionPokemon)rom.Edicion).Idioma == Idioma.Ingles && proyecto.Items[i].Nombre.StartsWith("TM"))
                        proyecto.Ataques[proyecto.Items[i].Index - lastItemNoAtack].Coleccion1 = Frame.Ataque.Coleccion.MT;
                    else proyecto.Ataques[proyecto.Items[i].Index - lastItemNoAtack].Coleccion1 = Frame.Ataque.Coleccion.MO;
                }
            }
        }
    }
}
