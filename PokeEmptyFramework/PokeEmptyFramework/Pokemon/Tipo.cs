using System.Collections.Generic;

namespace PokemonEmptyFramework
{
    public class Tipo
    {
        public class Efecto
        {
            public enum EfectividadAtaque
            {
                Inmune=0,
                PocoEfectivo=5,
                SuperEfectivo=20
                    //no se que pasaria si se pone un valor diferente...
         
            }
            public EfectividadAtaque EfectividadAtaqueBatalla { get; set; }
            public Tipo Tipo { get; set; }
        }

        public string Nombre { get; set; }
        public ImgWithPath Imagen { get; set; }
        public List<Efecto> TiposRelacionados { get; private set; }

       public Tipo()
        {
            TiposRelacionados = new List<Efecto>();
        }
    }
}