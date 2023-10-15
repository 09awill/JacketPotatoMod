using KitchenJacketPotato;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Profiling;
using UnityEngine.VFX;

namespace JacketPotatoMod.Customs.Cards
{
    class JacketPotatoWithBeansDish : CustomDish
    {
        public override string UniqueNameID => "Jacket Potato with Beans Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("JacketPotatoWithBeansIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool IsUnlockable => true;

        public int Difficulty()
        {
            return 1;
        }
        public override List<string> StartingNameSet => new List<string>
        {
            "Get your jacket you've pulled",
            "Spuds 'n' Hugs",
            "Jacket in the Box",
            "Tuna Turner's",
            "Butterly Bonkers",
            "Cheese the Day",
            "Bean There, Done That",
            "Tater Tots & Cracked Pots",
            "Baked to the Future",
            "Butter Believe It",
            "Elspudsie",
            "Boil 'em, Mash 'em, Stick 'em in a stew!"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.JacketPotatoWithBeans,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.RawBeans,
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
            { Locale.English, "Bake potato in oven and put on a plate, cook beans, Combine and serve!" },
            { Locale.French, "Cuisez la pomme de terre au four et mettez-la sur une assiette, faites cuire les haricots, combinez et servez !" },
            { Locale.German, "Kartoffel im Ofen backen und auf einen Teller legen, Bohnen kochen, kombinieren und servieren!" },
            { Locale.Spanish, "Hornee la patata en el horno y colóquela en un plato, cocine los frijoles, ¡combine y sirva!" },
            { Locale.Polish, "Upiecz ziemniaka w piekarniku i połóż na talerzu, gotuj fasolę, połącz i podawaj!" },
            { Locale.Russian, "Запеките картофель в духовке и положите на тарелку, приготовьте бобы, соедините и подавайте!" },
            { Locale.PortugueseBrazil, "Asse a batata no forno e coloque em um prato, cozinhe os feijões, combine e sirva!" },
            { Locale.Japanese, "オーブンでジャガイモを焼き、お皿に置き、豆を調理し、組み合わせて提供します！" },
            { Locale.ChineseSimplified, "在烤箱中烤土豆并放在盘子上，煮豆，混合并上菜！" },
            { Locale.ChineseTraditional, "在烤箱中烤土豆并放在盘子上，煮豆，混合并上菜！" },
            { Locale.Korean, "오븐에서 감자를 굽고 접시에 올려놓고, 콩을 요리하고, 섞어서 내세요!" },
            { Locale.Turkish, "Fırında patatesi pişirin ve tabağa koyun, fasulyeyi pişirin, karıştırın ve servis yapın!" },

        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Jacket Potato", "Adds Jacket Potato as a Base Dish", "Cosy comfort food") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Pomme de Terre en Robe des Champs", "Ajoute la pomme de terre en robe des champs comme plat de base", "Plat réconfortant") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Kartoffel in der Schale", "Fügt Kartoffel in der Schale als Grundgericht hinzu", "Gemütliches Komfortessen") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Patata en Chaqueta", "Agrega la patata en chaqueta como plato base", "Comida reconfortante y acogedora") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Ziemniak w Mundurku", "Dodaje ziemniaka w mundurku jako danie podstawowe", "Wygodne jedzenie") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Картофель в мундире", "Добавляет картофель в мундире как основное блюдо", "Уютная еда") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Batata em Casca", "Adiciona batata em casca como prato de base", "Comida reconfortante") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("ジャケットポテト", "ジャケットポテトをベースディッシュとして追加", "心地よい快適食品") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("马铃薯", "将马铃薯作为主食添加", "舒适的家常食物") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("馬鈴薯", "將馬鈴薯作為主食添加", "舒適的家常食物") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("자켓 감자", "자켓 감자를 기본 요리로 추가", "편안한 위로음식") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Ceket Patates", "Ceket patatesi ana yemek olarak ekler", "Rahatlatıcı huzur yemeği") ),

        };

        // Bean - Cooked, Bean - Juice Cooked, Bacon, Cooked Potato - Roast, Cooked Potato, Cheese - Default, Mayonnaise, Metal Dark
        public override void OnRegister(Dish gameDataObject)
        {
            gameDataObject.Difficulty = Difficulty();
            GameObject bacon = IconPrefab.GetChild("Bacon");
            foreach(var child in bacon.GetComponentsInChildren<Transform>()) {
                child.gameObject.ApplyMaterial("Bacon");
            }
            Mod.LogWarning("Bacon");
            IconPrefab.GetChild("Cheese/SubMesh_0.002").ApplyMaterial("Cheese - Default");
            Mod.LogWarning("Cheese");

            IconPrefab.GetChild("Beans/Cube/Beans").ApplyMaterial("Bean - Cooked");
            IconPrefab.GetChild("Beans/Beans (1)").ApplyMaterial("Bean - Cooked");
            IconPrefab.GetChild("Beans/Beans (2)").ApplyMaterial("Bean - Cooked");
            IconPrefab.GetChild("Beans/BeansLiquid").ApplyMaterial("Bean - Juice Cooked");
            IconPrefab.GetChild("Beans/Cylinder.001/BeansLiquid").ApplyMaterial("Bean - Juice Cooked");
            Mod.LogWarning("Beans");

            IconPrefab.GetChild("JacketPotato/Potato/SubMesh_0").ApplyMaterial("Cooked Potato - Roast");
            IconPrefab.GetChild("JacketPotato/Potato/SubMesh_1").ApplyMaterial("Cooked Potato");
            Mod.LogWarning("Potato 1");

            IconPrefab.GetChild("JacketPotato/Potato.001/SubMesh_0.001").ApplyMaterial("Cooked Potato - Roast");
            IconPrefab.GetChild("JacketPotato/Potato.001/SubMesh_1.001").ApplyMaterial("Cooked Potato");
            Mod.LogWarning("Potato 2");

            IconPrefab.GetChild("Plate/Plate/Cylinder").ApplyMaterial("Plate", "Plate - Ring");
            Mod.LogWarning("Plate");

            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == Mod.VFX_NAME).FirstOrDefault();
            if (asset != default)
            {
                VisualEffect vfx = IconPrefab.GetChild("Steam").AddComponent<VisualEffect>();
                vfx.visualEffectAsset = asset;
            }

        }
    }
}
