using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonEmptyFramework
{
    public class Evoluciones
    {
        //en exportar...
        //tener en cuenta el máximo si pasa de 5 que es el valor que hay por defecto se tiene que cambiar

        List<Evolucion> evoluciones;
        public Evoluciones()
        {
            evoluciones = new List<Evolucion>();
        }
        public Evolucion this[int index]
        {
            get { return evoluciones[index]; }
            set { evoluciones[index] = value; }
        }
        public int Count => evoluciones.Count;
        
        public void Add(Evolucion evo)
        {
            evoluciones.Add(evo);
        }
        public void Remove(Evolucion evo)
        {
            evoluciones.Remove(evo);
        }
        public void Remove(int index)
        {
            evoluciones.RemoveAt(index);
        }
        public static int MaxEvos(IList<Pokemon> pokedex)
        {
            int max = 1;
            for (int i = 0; i < pokedex.Count; i++)
                if (pokedex[i].Evoluciones.Count > max)
                    max = pokedex[i].Evoluciones.Count;
            return max;
        }
    }
    public class Evolucion
    {
        MetodoEvolucion metodo;
        int parametroMetodo;
        Pokemon pokemonAEVolucionar;
    }
    public class MetodoEvolucion
    {
        //mirar define en el import y tener en cuenta en el export
        string nombre;
        ushort metodo;
    }
}
