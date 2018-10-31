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
        public enum Felicidad
        {
            Minima = 0,
            Baja = 35,
            Normal = 70,
            MediAlta = 90,
            Alta = 100,
            MuyAlta = 140,
            Maxima = 255
        }
        public enum NivelEvs
        {
            Cero = 0,
            Uno = 1,
            Dos = 2,
            Tres = 3
        }
        public enum RatioCrecimiento
        {
            Exp1000000 = 0,
            Exp600000 = 1,
            Exp1640000 = 2,
            Exp1059860 = 3,
            Exp800000 = 4,
            Exp1250000 = 5
        }
        public enum RatioGenero
        {
            Macho100 = 0,
            Macho87 = 31,
            Macho75 = 63,
            Macho65 = 89,
            Macho50Hembra = 127,
            Hembra65 = 165,
            Hembra75 = 191,
            Hembra87 = 223,
            Hembra100 = 254,
            SinGenero = 255
        }
        int hp;
        int ataque;
        int defensa;
        int velocidad;

        int ratioCaptura;

        int expDejada;

        NivelEvs evHp;
        NivelEvs evAtaque;
        NivelEvs evDefensa;
        NivelEvs evVelocidad;
        NivelEvs evAtaqueEspecial;
        NivelEvs evDefensaEspecial;


        RatioGenero ratioGenero;
        int ciclosEclosionHuevo;
        Felicidad felicidad;
        RatioCrecimiento ratioCrecimiento;

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
        bool isFaceRight;

        public int Hp { get => hp; set => hp = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int RatioCaptura { get => ratioCaptura; set => ratioCaptura = value; }
        public int ExpDejada { get => expDejada; set => expDejada = value; }
        public NivelEvs EvHp { get => evHp; set => evHp = value; }
        public NivelEvs EvAtaque { get => evAtaque; set => evAtaque = value; }
        public NivelEvs EvDefensa { get => evDefensa; set => evDefensa = value; }
        public NivelEvs EvVelocidad { get => evVelocidad; set => evVelocidad = value; }
        public NivelEvs EvAtaqueEspecial { get => evAtaqueEspecial; set => evAtaqueEspecial = value; }
        public NivelEvs EvDefensaEspecial { get => evDefensaEspecial; set => evDefensaEspecial = value; }
        public RatioGenero Genero { get => ratioGenero; set => ratioGenero = value; }
        public int CiclosEclosionHuevo { get => ciclosEclosionHuevo; set => ciclosEclosionHuevo = value; }
        public Felicidad Amistad { get => felicidad; set => felicidad = value; }
        public RatioCrecimiento Crecimiento { get => ratioCrecimiento; set => ratioCrecimiento = value; }
        public Tipo Tipo1 { get => tipo1; set => tipo1 = value; }
        public Tipo Tipo2 { get => tipo2; set => tipo2 = value; }
        public Item Item1 { get => item1; set => item1 = value; }
        public Item Item2 { get => item2; set => item2 = value; }
        public GrupoHuevo GrupoHuevo1 { get => grupoHuevo1; set => grupoHuevo1 = value; }
        public GrupoHuevo GrupoHuevo2 { get => grupoHuevo2; set => grupoHuevo2 = value; }
        public Habilidad Habilidad1 { get => habilidad1; set => habilidad1 = value; }
        public Habilidad Habilidad2 { get => habilidad2; set => habilidad2 = value; }
        public int SafariRatioEscapar { get => safariRatioEscapar; set => safariRatioEscapar = value; }
        public ColorStat Color { get => color; set => color = value; }
        public bool IsFaceRight { get => isFaceRight; set => isFaceRight = value; }
    }
}
