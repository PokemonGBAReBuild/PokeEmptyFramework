using System;
using System.Collections.Generic;
using System.Text;
using Gabriel.Cat.S.Utilitats;
using PokemonGBAFrameWork;
using PokemonGBAFrameWork.Pokemon.Sprite;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Rom.Pokemon
{
    public static class Pokemon
    {
        public static void Load(Proyecto proyecto, string pathRom)
        {
            Load(proyecto, new PokemonGBAFrameWork.RomGba(pathRom));
        }
        public static void Load(Proyecto proyecto, PokemonGBAFrameWork.RomGba rom)
        {

            PokemonGBAFrameWork.PokemonCompleto[] pokedex = PokemonGBAFrameWork.PokemonCompleto.GetPokedex(rom);
            Frame.Pokemon pokemon;
            for (int i = 0; i < pokedex.Length; i++)
            {
                pokemon = new Frame.Pokemon();
                pokemon.Nombre.Text = pokedex[i].Nombre.Texto;

                pokemon.Orden.Local = pokedex[i].OrdenLocal.Orden;
                pokemon.Orden.Nacional = pokedex[i].OrdenNacional.Orden;

                pokemon.Stats.Amistad = (StatsBase.Felicidad)pokedex[i].Stats.BaseAmistad;
                pokemon.Stats.Ataque = pokedex[i].Stats.Ataque;
                pokemon.Stats.CiclosEclosionHuevo = pokedex[i].Stats.PasosParaEclosionarHuevo;
                pokemon.Stats.Color = (StatsBase.ColorStat)pokedex[i].Stats.ColorBaseStat;
                pokemon.Stats.Defensa = pokedex[i].Stats.Defensa;
                pokemon.Stats.EvAtaque = (StatsBase.NivelEvs)pokedex[i].Stats.AtaqueEvs;
                pokemon.Stats.EvAtaqueEspecial = (StatsBase.NivelEvs)pokedex[i].Stats.AtaqueEspecialEvs;
                pokemon.Stats.EvDefensa = (StatsBase.NivelEvs)pokedex[i].Stats.DefensaEvs;
                pokemon.Stats.EvDefensaEspecial = (StatsBase.NivelEvs)pokedex[i].Stats.DefensaEspecialEvs;
                pokemon.Stats.EvHp = (StatsBase.NivelEvs)pokedex[i].Stats.HpEvs;
                pokemon.Stats.EvVelocidad = (StatsBase.NivelEvs)pokedex[i].Stats.VelocidadEvs;
                pokemon.Stats.ExpDejada = pokedex[i].Stats.ExperienciaBase;
                pokemon.Stats.GrupoHuevo1 = proyecto.GrupoHuevos[(int)pokedex[i].Stats.GrupoHuevo1];
                pokemon.Stats.GrupoHuevo2 = proyecto.GrupoHuevos[(int)pokedex[i].Stats.GrupoHuevo2];
                pokemon.Stats.Habilidad1 = proyecto.Habilidades[pokedex[i].Stats.Habilidad1];
                pokemon.Stats.Habilidad2 = proyecto.Habilidades[pokedex[i].Stats.Habilidad2];
                pokemon.Stats.Hp = pokedex[i].Stats.Hp;
                pokemon.Stats.Item1 = proyecto.Items[pokedex[i].Stats.Objeto1];
                pokemon.Stats.Item2 = proyecto.Items[pokedex[i].Stats.Objeto2];
                pokemon.Stats.IsFaceRight = pokedex[i].Stats.IsFaceRight;
                pokemon.Stats.RatioCaptura = pokedex[i].Stats.RatioCaptura;
                pokemon.Stats.Crecimiento = (StatsBase.RatioCrecimiento)pokedex[i].Stats.Crecimiento;
                pokemon.Stats.Genero = (StatsBase.RatioGenero)pokedex[i].Stats.RatioSexo;
                pokemon.Stats.SafariRatioEscapar = pokedex[i].Stats.RatioDeEscaparZonaSafari;
                pokemon.Stats.Tipo1 = proyecto.Tipos[pokedex[i].Stats.Tipo1];
                pokemon.Stats.Tipo2 = proyecto.Tipos[pokedex[i].Stats.Tipo2];
                pokemon.Stats.Velocidad = pokedex[i].Stats.Velocidad;

                for (int j = 0; j < pokedex[j].AtaquesAprendidos.Ataques.Count; j++)
                    pokemon.AtaquesAprendidos.Ataques.Add(new AtaqueAprendido(pokedex[i].AtaquesAprendidos.Ataques[j].Nivel, proyecto.Ataques[pokedex[i].AtaquesAprendidos.Ataques[i].Ataque]));

                pokemon.PokedexData.Altura = pokedex[i].Descripcion.Altura;
                pokemon.PokedexData.Descripcion1 = pokedex[i].Descripcion.Texto;
                pokemon.PokedexData.EscalaEntrenador = pokedex[i].Descripcion.EscalaEntrenador;
                pokemon.PokedexData.EscalaPokemon = pokedex[i].Descripcion.EscalaPokemon;
                pokemon.PokedexData.Especie = pokedex[i].Descripcion.Especie;
                pokemon.PokedexData.OffsetEntrenador = pokedex[i].Descripcion.Numero2;
                pokemon.PokedexData.OffsetPokemon = pokedex[i].Descripcion.Numero;
                pokemon.PokedexData.Peso = pokedex[i].Descripcion.Peso;

                PonImagenes(pokemon.Imagenes.ImgsFront, pokedex[i].Sprites.SpritesFrontales.Sprites, "front");
                PonImagenes(pokemon.Imagenes.ImgsBack, pokedex[i].Sprites.SpritesTraseros.Sprites, "back");
                pokemon.Imagenes.ImgFootPrint = new ImgWithPath(pokedex[i].Huella.GetImagen()) { FileName = "foot_print" + ImgWithPath.EXTENSION };
                pokemon.Imagenes.PaletaNormal = new Paleta(pokedex[i].Sprites.PaletaNormal.Paleta.Colores);
                pokemon.Imagenes.PaletaShiny = new Paleta(pokedex[i].Sprites.PaletaShiny.Paleta.Colores);

                proyecto.Pokedex.Add(pokemon);
            }
        }

        private static void PonImagenes(List<ImgWithPath> lstDestino, Llista<BloqueImagen> sprites, string prefix)
        {
            ImgWithPath img;
            for (int i = 0; i < sprites.Count; i++)
            {
                img = new ImgWithPath(sprites[i]);
                img.FileName = string.Format("{0}_{1}{2}", prefix, i, ImgWithPath.EXTENSION);
                lstDestino.Add(img);
            }

        }
    }
}
