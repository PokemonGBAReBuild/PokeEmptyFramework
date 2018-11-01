using PokemonGBAFrameWork;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Rom.Pokemon
{
   public static class Tipo
    {
        public static void Load(Proyecto proyecto,RomGba rom)
        {
            PokemonGBAFrameWork.Pokemon.TipoCompleto[] tipos = PokemonGBAFrameWork.Pokemon.TipoCompleto.GetTipos(rom);
            Frame.Tipo tipo;
            for (int i=0;i<tipos.Length;i++)
            {
                tipo = new Frame.Tipo();
                tipo.Imagen.FileName = tipos[i].Nombre.Texto;
                tipo.Nombre = tipos[i].Nombre.Texto;

                proyecto.Tipos.Add(tipo);
            }
        }
    }
}
