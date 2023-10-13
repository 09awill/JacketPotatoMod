using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenData;
using System.Collections.Generic;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCan : CustomItem
    {
        public override string UniqueNameID => "Tuna Can";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaCan");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "T";
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Chop,
                Result = Mod.TunaCanOpened
            },

        };
        public override void OnRegister(Item gameDataObject)
        {
        }
    }
}
