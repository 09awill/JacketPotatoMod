using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Providers
{
    class FoilProvider : CustomAppliance
    {
        public override string UniqueNameID => "FoilProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FoilProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Foil Provider", "Allows a burrito to be wrapped in foil", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            KitchenPropertiesUtils.GetCItemProvider(Mod.Foil.ID, 0, 0, true, false, true, false, true, false, false),
            new CItemHolder()
        };
        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {

            new Appliance.ApplianceProcesses()
            {
                Process = Mod.Knead,                         
                Speed = 0.75f,                                             
                IsAutomatic = false                                       
            },
            new Appliance.ApplianceProcesses()
            {
                Process = Mod.Chop,
                Speed = 0.75f,
                IsAutomatic = false
            }

        };
        public override void OnRegister(Appliance gameDataObject)
        {
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") };
            Prefab.GetChild("BaseCounter").ApplyMaterial(mats);
            Prefab.GetChild("BaseCounter/BaseCountertop").ApplyMaterial(mats);
            Prefab.GetChild("BaseCounter/BaseCounterHandles").ApplyMaterial(mats);

            Prefab.GetChild("FoilDispenser").ApplyMaterial(mats);
            Prefab.GetChild("FoilDispenser/Plane").ApplyMaterial(mats);
            Prefab.GetChild("FoilDispenser/WoodenEnds").ApplyMaterial(mats);
            Prefab.GetChild("FoilDispenser/WoodenEnds/WoodenEnds.001").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            Prefab.GetChild("FoilDispenser/Foil").ApplyMaterial(mats);

            var holdTransform = Prefab.GetChild("BaseCounter/HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;

        }
    }
}
