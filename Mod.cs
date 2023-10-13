using BurritoMod.Customs;
using BurritoMod.Customs.BaseBurrito;
using BurritoMod.Customs.BeefBurrito;
using BurritoMod.Customs.BeefBurritoWithSalad;
using BurritoMod.Customs.BurritoSharedItems;
using BurritoMod.Customs.BurritoWithSalad;
using BurritoMod.Customs.Cards;
using BurritoMod.Customs.Providers;
using IngredientLib.Ingredient.Items;
using IngredientLib.Ingredient.Providers;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.Entities;
using UnityEngine;

// Namespace should have "Kitchen" in the beginning
namespace KitchenJacketPotato
{
    public class Mod : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Madvion.PlateUp.JacketPotato";
        public const string MOD_NAME = "Jacket Potato";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "Madvion";
        public const string MOD_GAMEVERSION = ">=1.1.3";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public static AssetBundle Bundle;

        // Vanilla Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);

        // Vanilla Items
        internal static Item JacketPotato => GetExistingGDO<Item>(ItemReferences.RoastPotatoItem);

        internal static Item Burnt => GetExistingGDO<Item>(ItemReferences.BurnedFood);
        internal static Item Beans => GetExistingGDO<Item>(ItemReferences.BeansCooked);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReferences.CheeseGrated);


        internal static Item Plate => Find<Item>(ItemReferences.Plate);
        internal static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);

        // Modded Items
        internal static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("Butter"));
        internal static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("Bacon"));





        internal static Item Foil => GetModdedGDO<Item, Foil>();



        // Modded Dishes
        internal static Dish BurritoDish => GetModdedGDO<Dish, BurritoDish>();

        // Modded Appliances 

        internal static Appliance ChickenProvider => GetModdedGDO<Appliance, ChickenProvider>();


        //Processes
        //public static Process WrapInFoil => GetModdedGDO<Process, WrapInFoil>();


        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");
            // Dishes and Cards
            
            AddGameDataObject<BurritoDish>();


            // Items

            AddGameDataObject<BurritoBasket>();
            AddGameDataObject<Foil>();

            AddGameDataObject<ChoppedChicken>();
            AddGameDataObject<ChoppedChickenCooked>();
            AddGameDataObject<ChoppedPorkWokCooked>();


            //Providers
            AddGameDataObject<BurritoBasketProvider>();
            AddGameDataObject<FoilProvider>();

            //Processes
            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            // TODO: Uncomment the following if you have an asset bundle.
            // TODO: Also, make sure to set EnableAssetBundleDeploy to 'true' in your ModName.csproj

            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            Bundle.LoadAllAssets<Texture2D>();
            Bundle.LoadAllAssets<Sprite>();
            Bundle.LoadAllAssets<AudioClip>();

            /*
            var spriteAsset = Bundle.LoadAsset<TMP_SpriteAsset>("Foil_Icon-01");
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
            spriteAsset.material = Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            spriteAsset.material.mainTexture = Bundle.LoadAsset<Texture2D>("Foil_Icon-01Tex");
            */
            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();
            //AudioUtils.AddProcessAudioClip(WrapInFoil.ID, AudioUtils.GetProcessAudioClip(GetExistingGDO<Process>(ProcessReferences.Cook).ID));
            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {

            };
        }

        internal class ComponentAccesserUtil : ItemGroupView
        {
            private static FieldInfo componentGroupField = ReflectionUtils.GetField<ItemGroupView>("ComponentGroups");
            private static FieldInfo componentLabelsField = ReflectionUtils.GetField<ItemGroupView>("ComponentLabels");



            public static void AddComponent(ItemGroupView viewToAddTo, params (Item item, GameObject gameObject)[] addedGroups)
            {
                List<ComponentGroup> componentGroups = componentGroupField.GetValue(viewToAddTo) as List<ComponentGroup>;
                
                foreach (var group in addedGroups)
                {
                    componentGroups.Add(new()
                    {
                        Item = group.item,
                        GameObject = group.gameObject
                    });
                }
                componentGroupField.SetValue(viewToAddTo, componentGroups);


            }
            public static void AddColourBlindLabels(ItemGroupView viewToAddTo, params (Item item, string colourBlindName)[] addedGroups)
            {
                List<ColourBlindLabel> componentGroups = componentLabelsField.GetValue(viewToAddTo) as List<ColourBlindLabel>;
                foreach (var group in addedGroups)
                {
                    componentGroups.Add(new()
                    {
                        Item = group.item,
                        Text = group.colourBlindName
                    });
                }
                componentLabelsField.SetValue(viewToAddTo, componentGroups);
            }
        }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
