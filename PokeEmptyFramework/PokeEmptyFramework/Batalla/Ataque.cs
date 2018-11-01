using System;
using System.Collections.Generic;

namespace PokemonEmptyFramework
{
    public class Ataque : IComparable<Ataque>
    {
        public enum Coleccion
        {
            Sin, MT, MO
        }

        public class Efecto
        {

            public enum Categoria
            {
                Fisico = 0,
                Especial = 1,
                Estatus = 2
            }

            public Tipo Type { get; set; }
            public int Accuracy { get; set; }
            public int PP { get; set; }

            public int Priority { get; set; }
            public int BasePower { get; set; }
            public Categoria Category { get; set; }//falta saber donde se pone...
            public int Target { get; set; }//hacer clase y coger metainfo para poderlo identificar...como minimo la posicion como está ahora
            public int Effect { get; set; }
            public int EffectAccuracy { get; set; }//mirar que es...
            //en un futuro hacerlo generico para poder expandir los efectos...
            public bool IsAffectedByMagicCoat { get; set; }
            public bool IsAffectedByMirrorMove { get; set; }
            public bool IsAffectedBySnatch { get; set; }

            public bool IsAffectedByProtect { get; set; }
            public bool MakesContact { get; set; }
            public bool IsAffectedByKingsRock { get; set; }
        }
        public class Concurso
        {

            int efecto;//mirar de poner más info y hacerlo generico
            int categoria;//mirar de poner más info y hacerlo generico
            Ataque comboStarter;
            List<Ataque> comboMovimientos;

            public Concurso()
            {
                ComboMovimientos = new List<Ataque>();
            }

            public int Efecto { get => efecto; set => efecto = value; }
            public int Categoria { get => categoria; set => categoria = value; }
            public Ataque ComboStarter { get => comboStarter; set => comboStarter = value; }
            public List<Ataque> ComboMovimientos { get => comboMovimientos; private set => comboMovimientos = value; }
        }
        public class ScriptAtaque
        {
            List<string> lineas;

            public List<string> Lineas { get => lineas; set => lineas = value; }
            //falta desarrollar la parte grafica y ayudar a formar un script valido.
        }
        string nombre;
        Coleccion coleccion;
        string descripcion;
        Efecto efecto;
        Concurso concurso;
        ScriptAtaque scriptAtaque;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        //buscar nombre...
        public Coleccion Coleccion1 { get => coleccion; set => coleccion = value; }
        public Efecto Efecto1 { get => efecto; set => efecto = value; }
        public Concurso Concurso1 { get => concurso; set => concurso = value; }
        public ScriptAtaque ScriptAtaque1 { get => scriptAtaque; set => scriptAtaque = value; }

        int IComparable<Ataque>.CompareTo(Ataque other)
        {
            Gabriel.Cat.S.Utilitats.CompareTo compareTo = other == null ? Gabriel.Cat.S.Utilitats.CompareTo.Inferior : Gabriel.Cat.S.Utilitats.CompareTo.Iguals;
            if (compareTo == Gabriel.Cat.S.Utilitats.CompareTo.Iguals)
            {
                compareTo = (Gabriel.Cat.S.Utilitats.CompareTo)Nombre.CompareTo(other.Nombre);
            }
            return (int)compareTo;
        }
    }

}
