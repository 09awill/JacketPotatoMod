using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using KitchenJacketPotato;
using UnityEngine;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCanOpened : CustomItem
    {
        public override string UniqueNameID => "Tuna Can Opened";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaCanOpened");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "T";

        public override void OnRegister(Item gameDataObject)
        {
        }
    }
}
