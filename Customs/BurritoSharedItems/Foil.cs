using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BurritoMod.Customs.BurritoSharedItems
{
    internal class Foil : CustomItem
    {
        public override string UniqueNameID => "Foil";
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Mod.FoilProvider;


        public override void OnRegister(Item gameDataObject)
        {
        }

    }

}