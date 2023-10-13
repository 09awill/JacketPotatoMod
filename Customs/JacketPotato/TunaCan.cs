using KitchenLib.Customs;
using KitchenJacketPotato;
using UnityEngine;
using KitchenData;
using System.Collections.Generic;
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
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Chop,
                Result = Mod.TunaCanOpened
            },

        };
        // Bean - Cooked, Bean - Juice Cooked, Bacon, Cooked Potato - Roast, Cooked Potato, Cheese - Default, Mayonnaise, Metal Dark
        public override void OnRegister(Item gameDataObject)
        {
            Prefab.GetChild("Tin/Cylinder.002").ApplyMaterial("Metal Dark");
            Prefab.GetChild("Tin/TinLAbel").ApplyMaterial("Blueberry 2");
            Prefab.GetChild("Tin").ApplyMaterial("Metal Dark");


        }
    }
}
