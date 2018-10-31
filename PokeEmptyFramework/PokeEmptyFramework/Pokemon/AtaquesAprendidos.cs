using System.Collections.Generic;

namespace PokemonEmptyFramework
{
    public class AtaquesAprendidos
    {
        public List<KeyValuePair<int,Ataque>> Ataques { get; private set; }
        public AtaquesAprendidos()
        {
            Ataques = new List<KeyValuePair<int, Ataque>>();
        }
    }
}
