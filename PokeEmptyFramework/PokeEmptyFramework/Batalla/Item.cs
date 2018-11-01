namespace PokemonEmptyFramework
{
    public class Item
    {
        public enum BolsilloObjetos
        {
            Desconocido = 0,
            Items = 1,
            Pokeballs = 2,
            MTMO = 3,
            Bayas = 4,
            ObjetosClave = 5//si se pueden sacar del juego lo quito por una clase como GrupoHuevo :)
        }
        public class Efecto
        {
            //mirar como va...
        }
        public string Nombre { get; set; }
        public ImgWithPath Imagen { get; set; }
        public Efecto EfectoAlUsar { get; set; }
        public int ExtraParameter { get; set; }
        public int OffsetBattleUsage { get; set; }
        public int BattleUsage { get; set; }
        public int Tipo { get; set; }
        public BolsilloObjetos Bolsillo { get; set; }
        public int KeyItemValue { get; set; }
        public string Descripcion { get; set; }
        public int BagKeyItem { get; set; }
        public int HoldEffect { get; set; }
        public int Price { get; set; }
        public int Index { get; set; }//es la posición o es otra cosa??
        public int Parameter { get; set; }
    }
}