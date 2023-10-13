using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class BeefBurritoMainWithExtrasCard : CustomDish
    {
        public override string UniqueNameID => "Beef Burrito MainWith Extras Card";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoExtrasInBasketIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool RequiredNoDishItem => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BeefBurritoMainCard
        };
        public override List<Unlock> HardcodedBlockers => new()
        {
            Mod.BeefBurritoDish,
            Mod.BeefBurritoWithExtrasCard
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BeefBurritoWithExtrasInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Lettuce,
            Mod.Tomato,
            Mod.Rice,
            Mod.Meat,
            Mod.Foil,
            Mod.BurritoBasket
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead
        };
        //Locale.English, "Combine chopped lettuce and tomato with the unwrapped base burrito, Interact to wrap and then toast and wrap in foil"
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine chopped lettuce and tomato with the unwrapped beef burrito, Interact to wrap and then wrap in foil. Serve in a basket!" },            
            { Locale.French, "Combinez de la laitue et des tomates hachées avec le burrito de bœuf déballé, interagissez pour l'envelopper et enveloppez-le ensuite dans du papier d'aluminium. Servez dans un panier !" },
            { Locale.German, "Kombiniere gehackten Salat und Tomaten mit dem ausgepackten Rindfleisch-Burrito, interagiere zum Einwickeln und wickle ihn dann in Folie ein. In einem Korb servieren!" },
            { Locale.Spanish, "Combina lechuga y tomate picados con el burrito de carne de res sin envolver, interactúa para envolver y luego envuelve en papel de aluminio. ¡Sirve en una canasta!" },
            { Locale.Polish, "Pokrój sałatę i pomidory, połącz je z rozpakowanym burrito z wołowiną, owiń w interakcji i następnie zawiń w folię. Podawaj w koszu!"},
            { Locale.Russian, "Сочетайте нарезанный салат и помидоры с распакованным буррито из говядины, взаимодействуйте, чтобы завернуть, а затем заверните в фольгу. Подавайте в корзине!" },
            { Locale.PortugueseBrazil, "Combine a alface e o tomate picados com o burrito de carne desembrulhado, interaja para embrulhar e depois envolva em papel alumínio. Sirva em uma cesta!" },
            { Locale.Japanese, "刻んだレタスとトマトをアンラップした牛肉ブリトと組み合わせ、包んでアクションしてからアルミホイルで包みます。バスケットで提供！" },
            { Locale.ChineseSimplified, "将切碎的生菜和西红柿与未包装的牛肉卷饼混合在一起，交互操作包裹，然后用锡纸包裹。在篮子里上菜！" },
            { Locale.ChineseTraditional, "將切碎的生菜和番茄與未包裝的牛肉捲餅混合在一起，互動操作包裹，然後用錫箔紙包裹。在籃子裡上菜！" },
            { Locale.Korean, "다진 양상추와 토마토를 미개한 소고기 부리또와 결합하여 덮고, 포장하는 상호 작용을 한 다음 호일에 싸서 바구니에 담아 제공합니다!" },
            { Locale.Turkish, "Kıyılmış marul ve domatesi açılmış etli burrito ile birleştirin, sarmak için etkileşim kurun ve ardından folyoya sarın. Bir sepet içinde servis yapın!" },

        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Beef Burrito with salad", "You have to add chopped lettuce and tomato to the beef burrito", "Gotta be healthy") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Burrito de bœuf avec salade", "Vous devez ajouter de la laitue et des tomates hachées au burrito de bœuf", "Il faut être en bonne santé.") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Rindfleisch-Burrito mit Salat", "Sie müssen gehackten Salat und Tomaten zum Rindfleisch-Burrito hinzufügen", "Muss gesund sein.") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Burrito de carne con ensalada", "Debes agregar lechuga y tomate picados al burrito de carne de res", "Tiene que ser saludable.") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Burrito z wołowiną z sałatką", "Musisz dodać pokrojoną sałatę i pomidory do burrito z wołowiną", "Trzeba być zdrowym.") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Буррито с говядиной и салатом", "Вы должны добавить нарезанный салат и помидоры в буррито с говядиной", "Надо быть здоровым.") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Burrito de carne com salada", "Você tem que adicionar alface e tomate picado ao burrito de carne", "Tem que ser saudável.") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("サラダを添えた牛肉ブリト", "牛肉ブリトに刻んだレタスとトマトを加える必要があります", "健康になるべきです。") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("牛肉卷饼配沙拉", "你必须将切碎的生菜和番茄加到牛肉卷饼中", "一定要健康。") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("牛肉捲餅配沙拉", "你必須將切碎的生菜和番茄加到牛肉捲餅中", "一定要健康。") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("샐러드가 있는 소고기 부리또", "소고기 부리또에 다진 양상추와 토마토를 추가해야 합니다", "건강해야합니다.") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Salata ile etli burrito", "Kıyılmış marul ve domatesi etli burrito'ya eklemeniz gerekiyor", "Sağlıklı olmak zorunda.") ),
        };

        public override void OnRegister(Dish gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            FoilWrappedBurrito.GetChild("StickerLettuce").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            FoilWrappedBurrito.GetChild("StickerTomato").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done") };
            FoilWrappedBurrito.GetChild("StickerBeef").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
        }
    }
}
