using IngredientLib.Ingredient.Items;
using IngredientLib.Ingredient.Providers;
using IngredientLib.Util;
using IngredientLib.Util.Custom;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BurritoMod.Customs.BurritoSharedItems
{
    internal class ChoppedPorkWokCooked : CustomItem
    {
        public override string UniqueNameID => "ChoppedPorkWokCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Pork - Chopped Cooked Wok");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override void OnRegister(Item gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Pork - Chopped Cooked Wok", "Porkchop Fat", "Porkchop");
        }
    }
}
