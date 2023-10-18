using KitchenJacketPotato;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using JacketPotatoMod.Customs.JacketPotato;
using System.Linq;
using Unity.Entities;
using UnityEngine.VFX;

namespace JacketPotatoMod.Customs.Cards
{
    class JacketPotatoWithButterDish : CustomDish
    {
        public override string UniqueNameID => "Jacket Potato with Butter Dish";
        public override DishType Type => DishType.Main;

        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithButterIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        public int Difficulty()
        {
            return 1;
        }

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.JacketPotatoWithButter,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.JacketPotatoWithBeansDish
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Butter,
            Mod.Potato,
            Mod.Plate,
            Mod.Pot,

        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.RequireOven
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Bake potato in oven and put on a plate, portion slice of butter, Combine and serve!" },
            { Locale.French, "Cuisez la pomme de terre au four et mettez-la sur une assiette, portionnez une tranche de beurre, combinez et servez !" },
            { Locale.German, "Kartoffel im Ofen backen und auf einen Teller legen, portionieren Sie eine Scheibe Butter, kombinieren und servieren!" },
            { Locale.Spanish, "Hornee la patata en el horno y colóquela en un plato, porcione una rebanada de mantequilla, combine y sirva!" },
            { Locale.Polish, "Upiecz ziemniaka w piekarniku i połóż na talerzu, podziel na porcje plaster masła, połącz i podawaj!" },
            { Locale.Russian, "Запеките картофель в духовке и положите на тарелку, порционируйте ломтик масла, соедините и подавайте!" },
            { Locale.PortugueseBrazil, "Asse a batata no forno e coloque em um prato, porcione uma fatia de manteiga, combine e sirva!" },
            { Locale.Japanese, "オーブンでジャガイモを焼き、お皿に置き、バターのスライスを分け、組み合わせて提供します！" },
            { Locale.ChineseSimplified, "在烤箱中烤土豆并放在盘子上，分配一片黄油，混合并上菜！" },
            { Locale.ChineseTraditional, "在烤箱中烤土豆并放在盘子上，分配一片黄油，混合并上菜！" },
            { Locale.Korean, "오븐에서 감자를 굽고 접시에 올려놓고, 버터 슬라이스를 부분적으로 분배하고, 섞어서 내세요!" },
            { Locale.Turkish, "Fırında patatesi pişirin ve tabağa koyun, tereyağının dilimini porsiyonlayın, karıştırın ve servis yapın!" },

        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Jacket Potato with Butter", "Adds butter as a filling for jacket potato", "Butter me up") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Pomme de Terre en Robe des Champs au Beurre", "Ajoute du beurre comme garniture pour la pomme de terre en robe des champs", "Beurrez-moi") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Kartoffel in der Schale mit Butter", "Fügt Butter als Füllung für Kartoffel in der Schale hinzu", "Butter mich ein") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Patata en Chaqueta con Mantequilla", "Agrega mantequilla como relleno para la patata en chaqueta", "Úntame de mantequilla") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Ziemniak w Mundurku z Masłem", "Dodaje masło jako nadzienie do ziemniaka w mundurku", "Masło mnie") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Картофель в мундире с маслом", "Добавляет масло в качестве начинки для картофеля в мундире", "Разотрите меня маслом") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Batata em Casca com Manteiga", "Adiciona manteiga como recheio para a batata em casca", "Passe a manteiga") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("バタージャケットポテト", "ジャケットポテトの具としてバターを追加", "バターでコーティング") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("黄油夹克马铃薯", "将黄油作为夹克马铃薯的馅料", "涂抹黄油") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("黃油夾克馬鈴薯", "將黃油作為夾克馬鈴薯的餡料", "塗抹黃油") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("버터 속 자켓 감자", "자켓 감자의 속으로 버터를 추가", "버터로 바르세요") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Tereyağlı Ceket Patates", "Ceket patates için tereyağı ekler", "Beni tereyağıyla sıvayın") ),

        };

        public override void OnRegister(Dish gameDataObject)
        {
            gameDataObject.Difficulty = Difficulty();
            IconPrefab.GetComponent<JacketPotatoWithButterItemGroupView>()?.Setup(IconPrefab);
            GameObject bacon = IconPrefab.GetChild("Bacon");
            foreach (var child in bacon.GetComponentsInChildren<Transform>())
            {
                child.gameObject.ApplyMaterial("Bacon");
            }
            IconPrefab.GetChild("Cheese/SubMesh_0.002").ApplyMaterial("Cheese - Default");
            IconPrefab.GetChild("Butter").ApplyMaterial("Butter");
            IconPrefab.GetChild("Butter/butter pool").ApplyMaterial("Butter");
            IconPrefab.GetChild("Butter/butter pool (1)").ApplyMaterial("Butter");
            IconPrefab.GetChild("JacketPotato/Potato/SubMesh_0").ApplyMaterial("Cooked Potato - Roast");
            IconPrefab.GetChild("JacketPotato/Potato/SubMesh_1").ApplyMaterial("Cooked Potato");
            IconPrefab.GetChild("JacketPotato/Potato.001/SubMesh_0.001").ApplyMaterial("Cooked Potato - Roast");
            IconPrefab.GetChild("JacketPotato/Potato.001/SubMesh_1.001").ApplyMaterial("Cooked Potato");
            IconPrefab.GetChild("Plate/Plate/Cylinder").ApplyMaterial("Plate", "Plate - Ring");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == Mod.VFX_NAME).FirstOrDefault();
            if (asset != default)
            {
                VisualEffect vfx = IconPrefab.GetChild("Steam").AddComponent<VisualEffect>();
                vfx.visualEffectAsset = asset;
            }
        }
    }
}
