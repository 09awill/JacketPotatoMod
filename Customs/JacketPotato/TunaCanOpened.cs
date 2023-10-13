using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
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
            Prefab.GetChild("Tin/TinLAbel").ApplyMaterial("Blueberry 2");
            Prefab.GetChild("Tin").ApplyMaterial("Metal Dark");
            Prefab.GetChild("Beans/Cube/Beans").ApplyMaterial("Tuna");
            Prefab.GetChild("Beans/Cylinder.001/BeansLiquid").ApplyMaterial("Tuna");

        }
    }
}
