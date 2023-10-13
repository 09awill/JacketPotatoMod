using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Cards
{
    class BeefBurritoMainCard : CustomDish
    {
        public override string UniqueNameID => "Beef Burrito Main Card";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoInBasketIcon");
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
        public override List<Unlock> HardcodedBlockers => new()
        {
            Mod.BeefBurritoDish
        };
        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BurritoDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BeefBurritoInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Rice,
            Mod.Meat,
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
            { Locale.English, "Chop Meat and stir fry with rice, combine with tortilla, Interact to wrap and then wrap in foil. Serve in a basket!" },
            { Locale.French, "Hacher la viande et faire sauter avec du riz, mélanger avec une tortilla, interagir pour envelopper et ensuite envelopper dans du papier d'aluminium. Servir dans un panier !" },
            { Locale.German, "Fleisch hacken und mit Reis anbraten, mit Tortilla kombinieren, interagieren, umwickeln und dann in Folie einwickeln. In einem Korb servieren!" },
            { Locale.Spanish,  "Picar la carne y saltear con arroz, combinar con tortilla, interactuar para envolver y luego envolver en papel de aluminio. ¡Servir en una canasta!" },
            { Locale.Polish, "Posiekaj mięso i smaż z ryżem, połącz z tortillą, zetnij do zapakowania, a następnie zawijaj w folię. Podawaj w koszu!" },
            { Locale.Russian, "Измельчить мясо и обжарить с рисом, сочетать с тортильей, взаимодействовать, чтобы завернуть, а затем завернуть в фольгу. Подать в корзине!" },
            { Locale.PortugueseBrazil, "Picar a carne e refogar com arroz, combinar com a tortilla, interagir para enrolar e depois embrulhar em papel alumínio. Servir em uma cesta!" },
            { Locale.Japanese, "肉を刻んで炒め、ご飯と混ぜ、トルティーヤと組み合わせて包み、アルミホイルで包む。バスケットで提供！" },
            { Locale.ChineseSimplified, "切肉炒饭，与玉米饼混合，交互包裹，然后用锡纸包裹。装在篮子里上桌！" },
            { Locale.ChineseTraditional, "切肉炒飯，與墨西哥薄餅混合，交互包裹，然後用錫箔包裹。裝在籃子裡上桌！" },
            { Locale.Korean, "고기를 다져 밥과 볶아 토르티야와 함께 섞고 포장하고 호일에 싸서 제공하세요!" },
            { Locale.Turkish,  "Etleri doğrayıp pilavla kavurun, tortilla ile karıştırın, sararak birleştirin ve ardından folyoya sarın. Bir sepet içinde servis yapın!" },
        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Beef Burrito", "Adds Beef Burrito in addition to chicken as a Main", "It means little donkey.") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Burrito de boeuf", "Ajoute le Burrito de Boeuf en plus du poulet en tant que plat principal", "Cela signifie petit âne.") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Rindfleisch-Burrito","Fügt den Rindfleisch-Burrito zusätzlich zum Hühnchen als Hauptgericht hinzu", "Das bedeutet kleiner Esel.") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Burrito de carne de res", "Agrega el Burrito de Carne de Res además del pollo como plato principal", "Significa pequeño burro.") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Burrito z wołowiną", "Dodaj burrito z wołowiną oprócz kurczaka jako danie główne", "To znaczy mała osiołek.") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Буррито с говядиной", "Добавьте буррито с говядиной в дополнение к курице в качестве основного блюда", "Это означает маленького осла.") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Burrito de carne", "Adiciona o Burrito de Carne além do frango como prato principal", "Significa burrinho.") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("ビーフブリト", "チキンに加えて牛肉ブリトをメインに追加", "それは小さなロバを意味します。") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("牛肉卷饼", "除了鸡肉外，加入牛肉卷饼作为主菜", "它的意思是小驴。") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("牛肉捲餅", "除了雞肉外，加入牛肉捲餅作為主菜", "它的意思是小驢。") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("소고기 부리또", "메인 요리로 치킨과 함께 소고기 부리또를 추가합니다", "이는 작은 당나귀를 의미합니다.") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Etli Burrito", "Tavukla birlikte Etli Burrito'yu ana yemek olarak ekler", "Bu küçük eşek anlamına gelir.") ),
        };

        public override void OnRegister(Dish gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done") };
            FoilWrappedBurrito.GetChild("StickerBeef").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket").GetChild("Paper").ApplyMaterial(mats);


        }
    }
}
