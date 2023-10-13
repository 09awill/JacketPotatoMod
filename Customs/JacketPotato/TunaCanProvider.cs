using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using KitchenJacketPotato;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCanProvider : CustomAppliance
    {
        public override string UniqueNameID => "Tuna Can Provider";
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Tuna Cans", "Provides Tuna Cans", new(), new()) )
        };
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Mod.TunaCan.ID)
        };
        public override void OnRegister(Appliance gameDataObject)
        {
        }
    }
}
