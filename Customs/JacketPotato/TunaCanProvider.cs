using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using KitchenJacketPotato;
using UnityEngine;
using Unity.Entities.UniversalDelegates;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCanProvider : CustomAppliance
    {
        public override string UniqueNameID => "Tuna Can Provider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaCanProvider");

        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Tuna Cans", "Provides Tuna Cans", new(), new()) ),
            ( Locale.French, LocalisationUtils.CreateApplianceInfo("Boîtes de Thon", "Fournit des boîtes de thon", new(), new()) ),
            ( Locale.German, LocalisationUtils.CreateApplianceInfo("Thunfischdosen", "Stellt Thunfischdosen bereit", new(), new()) ),
            ( Locale.Spanish, LocalisationUtils.CreateApplianceInfo("Latas de Atún", "Proporciona latas de atún", new(), new()) ),
            ( Locale.Polish, LocalisationUtils.CreateApplianceInfo("Puszki Tuńczyka", "Dostarcza puszki tuńczyka", new(), new()) ),
            ( Locale.Russian, LocalisationUtils.CreateApplianceInfo("Банки с тунцом", "Предоставляет банки с тунцом", new(), new()) ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateApplianceInfo("Latas de Atum", "Fornece latas de atum", new(), new()) ),
            ( Locale.Japanese, LocalisationUtils.CreateApplianceInfo("ツナ缶", "ツナ缶を提供", new(), new()) ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateApplianceInfo("金枪鱼罐头", "提供金枪鱼罐头", new(), new()) ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateApplianceInfo("金槍魚罐頭", "提供金槍魚罐頭", new(), new()) ),
            ( Locale.Korean, LocalisationUtils.CreateApplianceInfo("참치 캔", "참치 캔을 제공", new(), new()) ),
            ( Locale.Turkish, LocalisationUtils.CreateApplianceInfo("Ton Balığı Kutuları", "Ton balığı kutuları sunar", new(), new()) ),
        };
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Mod.TunaCan.ID)
        };
        public override void OnRegister(Appliance gameDataObject)
        {
            for(var i = 0 ; i < 5; i++) 
            {
                Prefab.GetChild($"Tin.00{i + 1}").ApplyMaterial("Metal Dark");
                Prefab.GetChild($"Tin.00{i+1}/TinLAbel").ApplyMaterial("Blueberry 2");
                Prefab.GetChild($"Tin.00{i+1}/Cylinder").ApplyMaterial("Metal Dark");
            }
            Mod.LogWarning("Done tins");
            Prefab.GetChild("Base").ApplyMaterial("Wood - Corkboard");
            Prefab.GetChild("Planks/SubMesh_0.005").ApplyMaterial("Wood - Default");
            Prefab.GetChild("Planks 2/SubMesh_0.004").ApplyMaterial("Wood - Default");
            Prefab.GetChild("Supports/SubMesh_0.006").ApplyMaterial("Wood - Default");
        }
    }
}
