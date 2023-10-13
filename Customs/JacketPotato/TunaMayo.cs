using KitchenData;
using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using static KitchenData.ItemGroup;
using System.Collections.Generic;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaMayo : CustomItemGroup
    {
        public override string UniqueNameID => "Tuna Mayo";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaMayo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "TM";
        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.TunaCanOpened,
                    Mod.Mayo,
                }
            },
        };
        public override void OnRegister(ItemGroup gameDataObject)
        {
        }
    }
}
