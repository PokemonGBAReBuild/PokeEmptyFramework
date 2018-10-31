using System;

namespace PokemonEmptyFramework
{
    public class Ataque:IComparable<Ataque>
    {
        public enum Coleccion
        {
            Sin,MT,MO
        }
        public class Efecto {
            /*
        .effect = EFFECT_HIT,
        .power = 0,
        .type = TYPE_NORMAL,
        .accuracy = 100,
        .pp = 0,
        .secondaryEffectChance = 0,
        .target = TARGET_SELECTED_POKEMON,
        .priority = 0,
        .flags = 0,
             */
        }
        string nombre;
        Coleccion coleccion;
        string descripcion;
        Efecto efecto;
        //la animacion en batalla graphics/battle_anims/sprites mirar como va
        //parte de los concursos
        int IComparable<Ataque>.CompareTo(Ataque other)
        {
            Gabriel.Cat.S.Utilitats.CompareTo compareTo = other == null ? Gabriel.Cat.S.Utilitats.CompareTo.Inferior : Gabriel.Cat.S.Utilitats.CompareTo.Iguals;
            if (compareTo == Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
            {
                compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)nombre.CompareTo(other.nombre);
            }
            return (int)compareTo;
        }
    }
   
}
