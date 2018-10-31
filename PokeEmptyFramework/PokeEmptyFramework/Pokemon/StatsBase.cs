using PokemonEmptyFramework.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonEmptyFramework
{
    public class StatsBase
    {
        public enum ColorStat
        {
            Rojo,
            Azul,
            Amarillo,
            Verde,
            Negro,
            Marron,
            Purpura,
            Gris,
            Blanco,
            Rosa
        }

        int hp;
        int ataque;
        int defensa;
        int velocidad;

        int ratioCaptura;

        int expDejada;

        int evHp;
        int evAtaque;
        int evDefensa;
        int evVelocidad;
        int evAtaqueEspecial;
        int evDefensaEspecial;


        int ratioGenero;
        int ciclosEclosionHuevo;
        int amistadInicial;
        int ratioCrecimiento;

        Tipo tipo1;
        Tipo tipo2;
        Item item1;
        Item item2;
        GrupoHuevo grupoHuevo1;
        GrupoHuevo grupoHuevo2;
        Habilidad habilidad1;
        Habilidad habilidad2;

        int safariRatioEscapar;
        ColorStat color;
        int noFlip;//poner un nombre más castellano


    }
}
