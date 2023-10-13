using KitchenJacketPotato;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JacketPotatoMod.Customs.Cards
{
    class JacketPotatoBaconToppingCard : CustomDish
    {
        public override string UniqueNameID => "Jacket Potato bacon topping";
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
                Ingredient = Mod.Bacon,
                MenuItem = Mod.JacketPotatoWithBeans
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.Bacon,
                MenuItem = Mod.JacketPotatoWithButter
            },
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Bacon
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook bacon and add to Jacket Potato!" },
            { Locale.French, "Cuisinez du bacon et ajoutez-le à la pomme de terre en robe des champs !" },
            { Locale.German, "Braten Sie Speck und fügen Sie ihn zur Pellkartoffel hinzu!" },
            { Locale.Spanish, "Cocine el bacon y añádalo a la patata asada." },
            { Locale.Polish, "Smaż boczek i dodaj go do ziemniaków w mundurkach!" },
            { Locale.Russian, "Приготовьте бекон и добавьте его к картофелю в мундире!" },
            { Locale.PortugueseBrazil, "Cozinhe o bacon e adicione à batata assada!" },
            { Locale.Japanese, "ベーコンを調理してジャケットポテトに追加してください！" },
            { Locale.ChineseSimplified, "煮培根，然后加入到烤土豆中！" },
            { Locale.ChineseTraditional, "煮培根，然后加入到烤土豆中！" },
            { Locale.Korean, "베이컨을 조리하고 구운 감자에 추가하세요!" },
            { Locale.Turkish, "Pastırmayı pişirin ve Fırın Patates'e ekleyin!" },

        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Jacket Potato Bacon Topping", "Adds Bacon as a topping for jacket potato", "Delicious bacon") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Garniture de Pomme de Terre au Bacon", "Ajoute du bacon comme garniture pour la pomme de terre en robe des champs", "Délicieux bacon") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Jacketkartoffel mit Specktopping", "Fügt Speck als Topping für die Jackenkartoffel hinzu", "Köstlicher Speck") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Topping de Tocino para Patata en Chaqueta", "Agrega tocino como topping para la patata en chaqueta", "Delicioso tocino") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Boczek na Ziemniaku w Pelerynie", "Dodaje boczek jako dodatek do ziemniaka w mundurku", "Pyszny boczek") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Топпинг картофель с беконом", "Добавьте бекон как топпинг для картофеля в мундире", "Вкусный бекон") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Cobertura de Bacon para Batata Assada", "Adiciona bacon como cobertura para a batata assada", "Bacon delicioso") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("ジャケットポテトベーコントッピング", "ジャケットポテト用のベーコンを追加", "美味しいベーコン") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("夹克土豆培根餐盖", "将培根添加为夹克土豆的餐盖", "美味的培根") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("夾克馬鈴薯培根餐蓋", "將培根添加為夾克馬鈴薯的餐蓋", "美味的培根") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("자켓 감자 베이컨 토핑", "자켓 감자 토핑으로 베이컨 추가", "맛있는 베이컨") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Ceket Patates Bacon Kaplama", "Ceket patates için kaplama olarak bacon ekler", "Lezzetli bacon") ),

        };
        public override void OnRegister(Dish gameDataObject)
        {
            gameDataObject.Difficulty = Difficulty();
        }


    }
}
