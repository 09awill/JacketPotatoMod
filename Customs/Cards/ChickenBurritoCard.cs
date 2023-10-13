using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Cards
{
    class ChickenBurritoCard : CustomDish
    {
        public override string UniqueNameID => "Chicken Burrito Card";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("ChickenBurritoInBasketIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool RequiredNoDishItem => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BeefBurritoDish
        };
        public override List<Unlock> HardcodedBlockers => new()
        {
            Mod.BurritoDish
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BurritoInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Rice,
            Mod.Chicken,
            Mod.Foil,
            Mod.BurritoBasket
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop Chicken and stir fry with rice, combine with tortilla, Interact to wrap and then wrap in foil. Serve in a basket!" },
            { Locale.French, "Hacher le poulet et le faire sauter avec du riz, combiner avec une tortilla, interagir pour envelopper et ensuite envelopper dans du papier d'aluminium. Servir dans un panier !" },
            { Locale.German, "Hacke das Hähnchen und brate es mit Reis an, kombiniere es mit Tortilla, interagiere zum Einwickeln und dann in Folie einwickeln. Servieren Sie in einem Korb!" },
            { Locale.Spanish, "Pica el pollo y saltea con arroz, combina con tortilla, interactúa para envolver y luego envuelve en papel de aluminio. ¡Sirve en una canasta!" },
            { Locale.Polish, "Posiekaj kurczaka i smaż z ryżem, połącz z tortillą, interakcja zawiń i owiń w folię. Podawaj w koszyku!" },
            { Locale.Russian, "Нарежьте курицу и обжарьте с рисом, сочетайте с тортильей, взаимодействуйте, чтобы завернуть, затем заверните в фольгу. Подавайте в корзине!" },
            { Locale.PortugueseBrazil, "Pique o frango e salteie com arroz, misture com a tortilla, interaja para embrulhar e, em seguida, embrulhe em papel alumínio. Sirva em uma cesta!" },
            { Locale.Japanese, "鶏肉を刻んでご飯と炒め、トルティーヤと組み合わせ、包んでからアルミホイルで包みます。バスケットで提供！" },
            { Locale.ChineseSimplified, "切鸡肉和炒饭，与玉米饼混合，互动包裹，然后用锡纸包裹。在篮子里上菜！" },
            { Locale.ChineseTraditional, "切雞肉和炒飯，與玉米餅混合，互動包裝，然後用錫箔包裹。在籃子裡上菜！" },
            { Locale.Korean, "닭고기를 다져서 밥과 볶아 토르티야와 함께 섞은 다음, 포장하고 호일로 싸세요. 바구니에 담아 서빙하세요!" },
            { Locale.Turkish, "Tavukları doğrayın ve pirinçle kavurun, tortilla ile birleştirin, sarın ve sonra alüminyum folyo ile sarın. Bir sepet içinde servis yapın!" },
        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Chicken Burrito", "Adds Chicken Burrito in addition to beef as a Main", "It means little donkey.") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Burrito au poulet", "Ajoute le burrito au poulet en plus du bœuf comme plat principal", "Ça signifie petit âne.") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Hühnerburrito", "Fügt den Chicken Burrito als Hauptgericht zusätzlich zum Rindfleisch hinzu", "Das bedeutet kleiner Esel.") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Burrito de pollo", "Agrega el Burrito de Pollo además del de carne como plato principal", "Significa pequeño burro.") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Burrito z kurczakiem", "Dodaje burrito z kurczakiem jako dodatkowe danie główne obok wołowiny", "To oznacza małego osła.") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Куриный буррито", "Добавьте куриный буррито в дополнение к говядине в качестве основного блюда", "Это означает маленького осла.") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Burrito de frango", "Adiciona o Burrito de Frango além do de carne como prato principal", "Significa burro pequeno.") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("チキンブリトー", "鶏肉のブリトーを牛肉に加えてメインディッシュにする", "それは小さなロバを意味します。") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("鸡肉卷饼", "除牛肉外，加入鸡肉卷饼作为主食", "意思是小驴。") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("雞肉捲餅",  "除了牛肉捲餅，還可以加入雞肉捲餅作為主餐", "意思是小驢子。") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo( "치킨 부리또", "소고기와 함께 닭고기 부리또도 메인 메뉴로 추가", "작은 당나귀를 의미합니다.") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Tavuklu burrito", "Et burritosuna ek olarak tavuk burritosunu ana yemek olarak ekleyin", "Bu küçük eşek anlamına gelir.") ),
        };

        public override void OnRegister(Dish gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);
            FoilWrappedBurrito.ApplyMaterialToChild("StickerChicken", "Bread - Inside Cooked");



            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket").GetChild("Paper").ApplyMaterial(mats);

        }
    }
}
