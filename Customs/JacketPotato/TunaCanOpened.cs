using KitchenData;
using KitchenLib.Customs;
using JacketPotatoMod.Utils;
using KitchenJacketPotato;
using UnityEngine;
using KitchenLib.Utils;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCanOpened : CustomItem
    {
        public override string UniqueNameID => "Tuna Can Opened";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaCanOpened");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "T";

        // Bean - Cooked, Bean - Juice Cooked, Bacon, Cooked Potato - Roast, Cooked Potato, Cheese - Default, Mayonnaise, Metal Dark
        public override void OnRegister(Item gameDataObject)
        {
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tin/TinLAbel"), "Blueberry 2");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tin"), "Metal Dark");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Beans/Cube/Beans"), "Tuna");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Beans/Cylinder.001/BeansLiquid"), "Tuna");

        }
    }
}
