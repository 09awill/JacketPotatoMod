using Kitchen;
using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenLib.Utils;
using KitchenData;
using static KitchenData.ItemGroup;
using System.Collections.Generic;
using BurritoMod.Customs.BaseBurrito;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class JacketPotatoWithTunaMayo : CustomItemGroup<JacketPotatoWithTunaItemGroupView>
    {
        public override string UniqueNameID => "Jacket Potato With Tuna Mayo";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithTunaMayo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.JacketPotato,
                    Mod.Plate
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.TunaMayo,
                }
            }
        };
        public override List<ItemGroupView.ColourBlindLabel> Labels => new List<ItemGroupView.ColourBlindLabel>()
        {
                new()
                {
                    Text = "JP",
                    Item = Mod.JacketPotato
                },
                new()
                {
                    Text = "TM",
                    Item = Mod.TunaMayo
                }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<JacketPotatoWithTunaItemGroupView>()?.Setup(Prefab);
        }
    }
    public class JacketPotatoWithTunaItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present

            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = Mod.Plate
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "JacketPotato"),
                    Item = Mod.JacketPotato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "TunaMayo"),
                    Item = Mod.TunaMayo
                },
            };
        }
    }
}
