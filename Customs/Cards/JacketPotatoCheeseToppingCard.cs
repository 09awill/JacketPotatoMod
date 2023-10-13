using KitchenJacketPotato;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JacketPotatoMod.Customs.Cards
{
    class JacketPotatoCheeseToppingCard : CustomDish
    {
        public override string UniqueNameID => "Jacket Potato cheese topping";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.JacketPotatoWithBeansDish
        };

        public int Difficulty()
        {
            return 1;
        }

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.ChoppedCheese,
                MenuItem = Mod.JacketPotatoWithBeans
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.ChoppedCheese,
                MenuItem = Mod.JacketPotatoWithButter
            },
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Cheese
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Chop,
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop cheese and add to Jacket Potato!" },
            { Locale.French, "Hachez le fromage et ajoutez-le à la pomme de terre en robe des champs !" },
            { Locale.German, "Schneiden Sie Käse und fügen Sie ihn zur Pellkartoffel hinzu!" },
            { Locale.Spanish, "Pique queso y añádalo a la patata asada." },
            { Locale.Polish, "Posiekaj ser i dodaj do ziemniaków w mundurkach!" },
            { Locale.Russian, "Нарежьте сыр и добавьте его к картофелю в мундире!" },
            { Locale.PortugueseBrazil, "Pique o queijo e adicione à batata assada!" },
            { Locale.Japanese, "チーズを刻んでジャケットポテトに追加してください！" },
            { Locale.ChineseSimplified, "切碎奶酪并加入到烤土豆中！" },
            { Locale.ChineseTraditional, "切碎奶酪并加入到烤土豆中！" },
            { Locale.Korean, "치즈를 다듬어서 자켓 감자에 추가하세요!" },
            { Locale.Turkish, "Peyniri doğrayın ve ceket patatese ekleyin!" },

        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Jacket Potato Cheese Topping", "Adds Cheese as a topping for jacket potato", "Nice and Cheesy") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Garniture de Pomme de Terre au Fromage", "Ajoute du fromage comme garniture pour la pomme de terre en robe des champs", "Délicieusement fromage") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Jacketkartoffel mit Käsetopping", "Fügt Käse als Topping für die Jackenkartoffel hinzu", "Schön käsig") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Topping de Queso para Patata en Chaqueta", "Agrega queso como topping para la patata en chaqueta", "Sabroso y quesoso") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Ser na Ziemniaku w Pelerynie", "Dodaje ser jako dodatek do ziemniaka w mundurku", "Pyszny serowy") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Сырный топпинг для картофеля", "Добавьте сыр в качестве топпинга для картофеля в мундире", "Вкусно и сырно") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Cobertura de Queijo para Batata Assada", "Adiciona queijo como cobertura para a batata assada", "Gostoso e queijo") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("ジャケットポテトチーズトッピング", "ジャケットポテト用のチーズをトッピング", "美味しくチーズ") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("夹克土豆芝士餐盖", "将芝士添加为夹克土豆的餐盖", "美味又多芝士") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("夾克馬鈴薯芝士餐蓋", "將芝士添加為夾克馬鈴薯的餐蓋", "美味又多芝士") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("자켓 감자 치즈 토핑", "자켓 감자 토핑으로 치즈 추가", "좋고 치즈") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Ceket Patates Peynir Kaplama", "Ceket patates için kaplama olarak peynir ekler", "Güzel ve peynirli") ),

        };
        public override void OnRegister(Dish gameDataObject)
        {
            gameDataObject.Difficulty = Difficulty();
        }
    }
}
