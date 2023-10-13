using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Providers
{
    internal class BurritoBasketProvider : CustomAppliance
    {
        public override string UniqueNameID => "BurritoBasketProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BurritoBasketProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Burrito Baskets", "Provides Burrito Baskets", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Mod.BurritoBasket.ID)
        };
        public override void OnRegister(Appliance gameDataObject)
        {

            GameObject basketStack = Prefab.GetChild("BasketStack");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            basketStack.GetChild("BurritoBasket").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (1)").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (2)").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (3)").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };

            basketStack.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (1)/Paper").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (2)/Paper").ApplyMaterial(mats);
            basketStack.GetChild("BurritoBasket (3)/Paper").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood 4 - Painted") };

            Prefab.GetChild("Tray Counter/Counter2/Counter").ApplyMaterial(mats);
            Prefab.GetChild("Tray Counter/Counter2/Counter Doors").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") };
            Prefab.GetChild("Tray Counter/Counter2/Counter Surface").ApplyMaterial(mats);
            Prefab.GetChild("Tray Counter/Counter2/Counter Top").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Knob") };
            Prefab.GetChild("Tray Counter/Counter2/Handles").ApplyMaterial(mats);
        }
    }
}
