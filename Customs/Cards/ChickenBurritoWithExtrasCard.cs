using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class ChickenBurritoWithExtrasCard : CustomDish
    {
        public override string UniqueNameID => "Chicken Burrito With Extras Card";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("ChickenBurritoExtrasInBasket");
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
            Mod.ChickenBurritoCard
        };
        public override List<Unlock> HardcodedBlockers => new()
        {
            Mod.BurritoDish,
            Mod.BurritoWithExtrasCard
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BurritoWithExtrasInaBasket,
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
            Mod.Chicken,
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
            { Locale.English, "Combine chopped lettuce and tomato with the unwrapped chicken burrito, Interact to wrap and then wrap in foil. Serve in a basket!" },
            { Locale.French, "Mélangez de la laitue et des tomates hachées avec le burrito de poulet non emballé, Enroulez-le en interagissant puis enveloppez-le dans du papier d'aluminium. Servez dans un panier !" },
            { Locale.German, "Kombiniere gehackten Salat und Tomaten mit dem ausgepackten Hähnchen-Burrito, Wickeln Sie ihn durch Interaktion ein und wickeln Sie ihn dann in Folie ein. Servieren Sie ihn in einem Korb!" },
            { Locale.Spanish, "Combina la lechuga y el tomate picado con el burrito de pollo sin envolver, Interactúa para envolverlo y luego envuélvelo en papel de aluminio. ¡Sirve en una canasta!" },
            { Locale.Polish, "Połącz posiekaną sałatę i pomidory z niezapakowanym burrito z kurczakiem, Zawiń za pomocą interakcji, a następnie zawijaj w folię aluminiową. Podawaj w koszyku!" },
            { Locale.Russian,  "Сочетайте нарезанный листовой салат и помидоры с распакованным куриным буррито, Оберните его, взаимодействуя, а затем заверните в фольгу. Подавайте в корзине!" },
            { Locale.PortugueseBrazil, "Combine alface e tomate picados com o burrito de frango desembrulhado, Interaja para enrolar e depois embrulhe em papel alumínio. Sirva em uma cesta!" },
            { Locale.Japanese, "刻んだレタスとトマトをアンラップしたチキンブリトーと組み合わせ、インタラクトして包み、アルミホイルで包んで、バスケットに盛り付けてください！" },
            { Locale.ChineseSimplified, "将切碎的生菜和番茄与未包装的鸡肉卷饼结合起来，通过交互包裹，然后用箔纸包裹。在篮子里上菜！" },
            { Locale.ChineseTraditional,  "將切碎的生菜和番茄與未包裝的雞肉捲餅結合在一起，透過互動包裹，然後用錫箔紙包裹。在籃子中上菜！" },
            { Locale.Korean, "다진 양상추와 토마토를 포함하여 포장하지 않은 치킨 부리또와 결합하여 상호작용하여 포장한 후 호일로 감싸세요. 바구니에 담아 서빙하세요!" },
            { Locale.Turkish, "Doğranmış marul ve domatesi açılmış tavuklu burrito ile birleştirin, etkileşime girerek sarın ve sonra folyoya sarın. Bir sepet içinde servis yapın!" },
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Chicken Burrito with salad", "You have to add chopped lettuce and tomato to the chicken burrito", "Gotta be healthy") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Burrito au poulet avec salade", "Vous devez ajouter de la laitue et des tomates hachées au burrito de poulet.", "Il faut manger sainement") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Hühnchen-Burrito mit Salat", "Sie müssen gehackten Salat und Tomaten zum Hühnchen-Burrito hinzufügen.", "Es muss gesund sein") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Burrito de pollo con ensalada", "Debes agregar lechuga y tomate picado al burrito de pollo.", "Tiene que ser saludable") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Burrito z kurczakiem i sałatką",  "Musisz dodać posiekaną sałatę i pomidory do burrito z kurczakiem.", "Musisz jeść zdrowo") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Куриный буррито с салатом", "Вы должны добавить нарезанный салат и помидоры в куриный буррито.", "Нужно есть здоровую пищу") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Burrito de Frango com Salada", "Você tem que adicionar alface e tomate picado ao burrito de frango.", "Tem que ser saudável") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("サラダを添えたチキンブリトー", "チキンブリトーに刻んだレタスとトマトを追加する必要があります。", "健康的である必要があります") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("沙拉鸡肉卷", "您需要将切碎的生菜和番茄添加到鸡肉卷饼中。", "必须要健康") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("沙拉雞肉捲餅", "您需要將切碎的生菜和番茄添加到雞肉捲餅中。", "必須要健康") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("샐러드가 첨가된 치킨 부리또", "닭고기 부리또에 다진 양상추와 토마토를 추가해야 합니다.", "건강해야 합니다") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo( "Salatalı Tavuklu Burrito",  "Tavuk burritosuna doğranmış marul ve domates eklemeniz gerekiyor.", "Sağlıklı olması gerekir") ),
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

            FoilWrappedBurrito.ApplyMaterialToChild("StickerChicken", "Bread - Inside Cooked");



            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
        }
    }
}
