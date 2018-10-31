using System;
using System.Collections.Generic;

namespace PokemonEmptyFramework
{
    public class AtaquesAprendidos
    {
        public List<AtaqueAprendido> Ataques { get; private set; }
        public AtaquesAprendidos()
        {
            Ataques = new List<AtaqueAprendido>();
        }
    }
    public class AtaqueAprendido:IComparable<AtaqueAprendido>
    {
        int nivel;
        Ataque ataque;

        public AtaqueAprendido(int nivel, Ataque ataque)
        {
            this.Nivel = nivel;
            this.Ataque = ataque;
        }

        public int Nivel { get => nivel; set => nivel = value; }
        public Ataque Ataque { get => ataque; set => ataque = value; }

        int IComparable<AtaqueAprendido>.CompareTo(AtaqueAprendido other)
        {
            Gabriel.Cat.S.Utilitats.CompareTo compareTo = other == null ? Gabriel.Cat.S.Utilitats.CompareTo.Inferior : Gabriel.Cat.S.Utilitats.CompareTo.Iguals;
            if(compareTo==Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
            {
                compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)Nivel.CompareTo(other.Nivel);
                if (compareTo == Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
                {
                    compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)((IComparable<Ataque>)Ataque).CompareTo(other.Ataque);

                }
            }
            return (int)compareTo;
        }
    }
}
