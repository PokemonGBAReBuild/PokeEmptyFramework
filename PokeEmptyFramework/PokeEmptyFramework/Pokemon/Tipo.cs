using System.Collections.Generic;

namespace PokemonEmptyFramework
{
    public class Tipo
    {
        public class Efecto
        {
            public enum EfectividadAtaque
            {
                Inmune,
                PocoEfectivo,
                Efectivo,
                SuperEfectivo
                    //poner más si  faltan
            }
            public EfectividadAtaque EfectividadAtaqueBatalla { get; set; }
            public Tipo Tipo { get; set; }
        }

        public string Nombre { get; set; }
        public ImgWithPath Imagen { get; set; }
        public List<Efecto> TiposRelacionados { get; private set; }

       
    }
}