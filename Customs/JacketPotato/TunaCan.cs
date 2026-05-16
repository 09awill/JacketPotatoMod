using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenData;
using System.Collections.Generic;
using JacketPotatoMod.Utils;
using KitchenLib.Utils;

namespace JacketPotatoMod.Customs.JacketPotato
{
    public class TunaCan : CustomItem
    {
        public override string UniqueNameID => "Tuna Can";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TunaCan");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override string ColourBlindTag => "T";
        public override Appliance DedicatedProvider => Mod.TunaCanProvider;
        public override List<Item.ItemProcess> Processes =>
        [
            new()
            {
                Duration = 1,
                Process = Mod.Chop,
                Result = Mod.TunaCanOpened
            }


        ];
        // Bean - Cooked, Bean - Juice Cooked, Bacon, Cooked Potato - Roast, Cooked Potato, Cheese - Default, Mayonnaise, Metal Dark
        public override void OnRegister(Item gameDataObject)
        {
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tin/Cylinder.002"), "Metal Dark");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tin/TinLAbel"), "Blueberry 2");
            MaterialHelper.ApplyMaterial(Prefab.GetChild("Tin"), "Metal Dark");
        }
    }
}
