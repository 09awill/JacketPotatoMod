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
using System.Text;
using IngredientLib.Ingredient.Items;
using Unity.Entities;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class JacketPotatoWithBeans : CustomItemGroup<JacketPotatoWithBeansItemGroupView>
    {
        public override string UniqueNameID => "Jacket Potato With Beans";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithBeans");
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
                    Mod.Plate,
                    Mod.JacketPotato,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.Beans,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 0,
                RequiresUnlock= true,
                Items = new List<Item>()
                {
                    Mod.Bacon
                }
            }, new ItemSet()
            {
                Max = 1,
                Min = 0,
                RequiresUnlock= true,
                Items = new List<Item>()
                {
                    Mod.ChoppedCheese,
                }
            }
        };
        public override List<ItemGroupView.ColourBlindLabel> Labels => new List<ItemGroupView.ColourBlindLabel>()
        {
                new()
                {
                    Text = "C",
                    Item = Mod.ChoppedCheese
                },
                new()
                {
                    Text = "Bac",
                    Item = Mod.Bacon
                },
                new()
                {
                    Text = "Be",
                    Item = Mod.Beans
                }
        };

        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<JacketPotatoWithBeansItemGroupView>()?.Setup(Prefab);
            //Prefab.GetChild("Side Container").AddComponent<DoubleSideFixer>();
            GameObject bacon = Prefab.GetChild("Bacon");
            foreach (var child in bacon.GetComponentsInChildren<Transform>())
            {
                child.gameObject.ApplyMaterial("Bacon");
            }
            Mod.LogWarning("Bacon");
            Prefab.GetChild("Cheese/SubMesh_0.002").ApplyMaterial("Cheese - Default");
            Mod.LogWarning("Cheese");

            Prefab.GetChild("Beans/Cube/Beans").ApplyMaterial("Bean - Cooked");
            Prefab.GetChild("Beans/Beans (1)").ApplyMaterial("Bean - Cooked");
            Prefab.GetChild("Beans/Beans (2)").ApplyMaterial("Bean - Cooked");
            Prefab.GetChild("Beans/BeansLiquid").ApplyMaterial("Bean - Juice Cooked");
            Prefab.GetChild("Beans/Cylinder.001/BeansLiquid").ApplyMaterial("Bean - Juice Cooked");
            Mod.LogWarning("Beans");
            Prefab.GetChild("JacketPotato/Potato/SubMesh_0").ApplyMaterial("Cooked Potato - Roast");
            Prefab.GetChild("JacketPotato/Potato/SubMesh_1").ApplyMaterial("Cooked Potato");
            Mod.LogWarning("Potato");

            Prefab.GetChild("JacketPotato/Potato.001/SubMesh_0.001").ApplyMaterial("Cooked Potato - Roast");
            Prefab.GetChild("JacketPotato/Potato.001/SubMesh_1.001").ApplyMaterial("Cooked Potato");
            Mod.LogWarning("Potato 2");

            Prefab.GetChild("Plate/Plate/Cylinder").ApplyMaterial("Plate", "Plate - Ring");
            Mod.LogWarning("Plate");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == Mod.VFX_NAME).FirstOrDefault();
            if (asset != default)
            {
                VisualEffect vfx = Prefab.GetChild("Steam").AddComponent<VisualEffect>();
                vfx.visualEffectAsset = asset;
            }
        }
    }
    public class JacketPotatoWithBeansItemGroupView : ItemGroupView
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Beans"),
                    Item = Mod.Beans
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
