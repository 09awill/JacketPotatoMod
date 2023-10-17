using Kitchen;
using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenLib.Utils;
using KitchenData;
using static KitchenData.ItemGroup;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.VFX;
using KitchenLib.References;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class JacketPotatoWithButter : CustomItemGroup<JacketPotatoWithButterItemGroupView>
    {
        public override string UniqueNameID => "Jacket Potato With Butter";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithButter");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => Mod.Plate;
        public override Item DirtiesTo => Mod.DirtyPlate;
        public override bool CanContainSide => true;

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
                IsMandatory = false,
                Items = new List<Item>()
                {
                    Mod.ButterSlice,
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock= true,
                Items = new List<Item>()
                {
                    Mod.ChoppedCheese,
                    Mod.Bacon
                }
            }
        };
        public override List<ItemGroupView.ColourBlindLabel> Labels => new List<ItemGroupView.ColourBlindLabel>()
        {
                new()
                {
                    Text = "P",
                    Item = Mod.Plate
                },
                new()
                {
                    Text = "Bu",
                    Item = Mod.ButterSlice
                },
                new()
                {
                    Text = "C",
                    Item = Mod.ChoppedCheese
                },
                new()
                {
                    Text = "Bac",
                    Item = Mod.Bacon
                }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<JacketPotatoWithButterItemGroupView>()?.Setup(Prefab);

            GameObject bacon = Prefab.GetChild("Bacon");
            foreach (var child in bacon.GetComponentsInChildren<Transform>())
            {
                child.gameObject.ApplyMaterial("Bacon");
            }
            Prefab.GetChild("Cheese/SubMesh_0.002").ApplyMaterial("Cheese - Default");
            Prefab.GetChild("Butter").ApplyMaterial("Butter");
            Prefab.GetChild("Butter/butter pool").ApplyMaterial("Butter");
            Prefab.GetChild("Butter/butter pool (1)").ApplyMaterial("Butter");
            Prefab.GetChild("JacketPotato/Potato/SubMesh_0").ApplyMaterial("Cooked Potato - Roast");
            Prefab.GetChild("JacketPotato/Potato/SubMesh_1").ApplyMaterial("Cooked Potato");
            Prefab.GetChild("JacketPotato/Potato.001/SubMesh_0.001").ApplyMaterial("Cooked Potato - Roast");
            Prefab.GetChild("JacketPotato/Potato.001/SubMesh_1.001").ApplyMaterial("Cooked Potato");
            Prefab.GetChild("Plate/Plate/Cylinder").ApplyMaterial("Plate", "Plate - Ring");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == Mod.VFX_NAME).FirstOrDefault();
            if (asset != default)
            {
                VisualEffect vfx = Prefab.GetChild("Steam").AddComponent<VisualEffect>();
                vfx.visualEffectAsset = asset;
            }
        }
    }
    public class JacketPotatoWithButterItemGroupView : ItemGroupView
    {
        private GameObject jacketPotato = null;
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            jacketPotato = prefab.GetChild("JacketPotato");
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "PotatoToTrickChef"),
                    Item = Mod.JacketPotato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Butter"),
                    Item = Mod.ButterSlice
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese"),
                    Item = Mod.ChoppedCheese
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon"),
                    Item = Mod.Bacon
                }
            };
        }
        public override void PerformUpdate(int item_id, ItemList components)
        {
            base.PerformUpdate(item_id, components);
            int potCount = 0;
            foreach (int item in components)
            {
                if (item == ItemReferences.RoastPotatoItem) potCount++;
            }
            GameObject roastPot = gameObject.GetChild("Side Container/Side Prefab(Clone)/Roast Potato");
            if (roastPot != null) roastPot.GetChild(0).SetActive(potCount > 1);
        }

    }
}
