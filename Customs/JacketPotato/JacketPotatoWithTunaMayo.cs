using Kitchen;
using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenLib.Utils;
using KitchenData;
using static KitchenData.ItemGroup;
using System.Collections.Generic;
using System.Linq;
using JacketPotatoMod.Utils;
using UnityEngine.VFX;
using KitchenLib.References;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class JacketPotatoWithTunaMayo : CustomItemGroup<JacketPotatoWithTunaItemGroupView>
    {
        public override string UniqueNameID => "Jacket Potato With Tuna Mayo";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithTunaMayo");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => Mod.Plate;
        public override Item DirtiesTo => Mod.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets =>
        [
            new()
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
            new()
            {
                Max = 1,
                Min = 1,
                IsMandatory = false,
                Items = new List<Item>()
                {
                    Mod.TunaMayo
                }
            }
        ];
        
        public override List<ItemGroupView.ColourBlindLabel> Labels =>
        [
            new()
            {
                Text = "TM",
                Item = Mod.TunaMayo
            }
        ];
        
        // Bean - Cooked, Bean - Juice Cooked, Bacon, Cooked Potato - Roast, Cooked Potato, Cheese - Default, Mayonnaise, Metal Dark
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<JacketPotatoWithTunaItemGroupView>()?.Setup(Prefab);

            MaterialHelper.ApplyMaterial(Prefab.GetChild("JacketPotato/Potato/SubMesh_0"), "Cooked Potato - Roast");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("JacketPotato/Potato/SubMesh_1"), "Cooked Potato");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tuna/Cube/Beans"), "Tuna");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tuna/Cylinder.001/BeansLiquid"), "Tuna");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("JacketPotato/Potato.001/SubMesh_0.001"), "Cooked Potato - Roast");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("JacketPotato/Potato.001/SubMesh_1.001"), "Cooked Potato");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Plate/Plate/Cylinder"), "Plate", "Plate - Ring");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == Mod.VFX_NAME).FirstOrDefault();
            if (asset != default)
            {
                VisualEffect vfx = Prefab.GetChild("Steam").AddComponent<VisualEffect>();
                vfx.visualEffectAsset = asset;
            }
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "PotatoToTrickChef"),
                    Item = Mod.JacketPotato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tuna"),
                    Item = Mod.TunaMayo
                },
            };
        }
        public override void PerformUpdate(int item_id, ItemList components, bool isOrder)
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
