using System;
using System.Collections.Generic;
using System.Text;
using Frame = PokemonEmptyFramework;
namespace PokemonEmptyFramework.Import.Rom.Batalla
{
    public static class Item
    {
        public static void Load(Proyecto proyecto,PokemonGBAFrameWork.RomGba rom)
        {
            PokemonGBAFrameWork.ObjetoCompleto[] objetos=PokemonGBAFrameWork.ObjetoCompleto.GetObjetos(rom);
            Frame.Item item;
            for(int i=0;i<objetos.Length;i++)
            {
                item = new Frame.Item();
                item.Nombre = objetos[i].Datos.Nombre;
                item.Imagen = new ImgWithPath(objetos[i].Datos.Nombre, objetos[i].Sprite.Imagen);

                item.BagKeyItem = objetos[i].Datos.BagKeyItem;
                item.BattleUsage =Convert.ToInt32((uint)objetos[i].Datos.BattleUsage);
                item.Bolsillo = (Frame.Item.BolsilloObjetos)objetos[i].Datos.Bolsillo;
                item.Descripcion = objetos[i].Datos.Descripcion.Texto;
                item.ExtraParameter = Convert.ToInt32((uint)objetos[i].Datos.ExtraParameter);
                item.HoldEffect = objetos[i].Datos.HoldEffect;
                item.Index = objetos[i].Datos.Index;//mirar que no sea la posición porque seria algo a no tener en cuenta...
                item.KeyItemValue = objetos[i].Datos.KeyItemValue;
                item.OffsetBattleUsage = objetos[i].Datos.PointerBattleUsage.Offset;
                item.Parameter = objetos[i].Datos.Parameter;
                item.Price = objetos[i].Datos.Price;
                item.Tipo = objetos[i].Datos.Tipo;

                proyecto.Items.Add(item);
            }
        }
    }
}
