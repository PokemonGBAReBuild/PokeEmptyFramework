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

        int IComparable<AtaqueAprendido>.CompareTo(AtaqueAprendido other)
        {
            Gabriel.Cat.S.Utilitats.CompareTo compareTo = other == null ? Gabriel.Cat.S.Utilitats.CompareTo.Inferior : Gabriel.Cat.S.Utilitats.CompareTo.Iguals;
            if(compareTo==Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
            {
                compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)nivel.CompareTo(other.nivel);
                if (compareTo == Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
                {
                    compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)((IComparable<Ataque>)ataque).CompareTo(other.ataque);

                }
            }
            return (int)compareTo;
        }
    }
}
