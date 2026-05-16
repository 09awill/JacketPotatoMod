using JacketPotatoMod.Customs.Cards;
using JacketPotatoMod.Customs.JacketPotato;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Linq;
using System.Reflection;
using KitchenLib.Interfaces;
using UnityEngine;

// Namespace should have "Kitchen" in the beginning
namespace KitchenJacketPotato
{
    public class Mod : BaseMod, IAutoRegisterAll
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Madvion.PlateUp.JacketPotato";
        public const string MOD_NAME = "Jacket Potato";
        public const string MOD_VERSION = "0.1.9";
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

        public const string VFX_NAME = "Steam";

        // Vanilla Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process RequireOven => GetExistingGDO<Process>(ProcessReferences.RequireOven);
        
        // Vanilla Items
        internal static Item JacketPotato => GetExistingGDO<Item>(ItemReferences.RoastPotatoItem);
        internal static Item RawBeans => GetExistingGDO<Item>(ItemReferences.BeansIngredient);
        internal static Item Beans => GetExistingGDO<Item>(ItemReferences.BeansServing);
        internal static Item ChoppedCheese => GetExistingGDO<Item>(ItemReferences.CheeseGrated);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReferences.Cheese);
        internal static Item Mayo => GetExistingGDO<Item>(ItemReferences.Mayonnaise);
        internal static Item Potato => GetExistingGDO<Item>(ItemReferences.Potato);
        internal static Item Pot => GetExistingGDO<Item>(ItemReferences.Pot);
        internal static Item Plate => Find<Item>(ItemReferences.Plate);
        internal static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);
        internal static Item Egg => Find<Item>(ItemReferences.Egg);
        internal static Item Oil => Find<Item>(ItemReferences.Oil);


        // Modded Items
        internal static Item Butter => Find<Item>(IngredientLib.References.GetIngredient("Butter"));
        internal static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("Butter"));
        internal static Item Bacon => Find<Item>(IngredientLib.References.GetIngredient("Bacon"));
        internal static Item Pork => Find<Item>(IngredientLib.References.GetIngredient("pork"));

        // Added Items
        internal static ItemGroup JacketPotatoWithBeans => GetModdedGDO<ItemGroup, JacketPotatoWithBeans>();
        internal static ItemGroup JacketPotatoWithButter => GetModdedGDO<ItemGroup, JacketPotatoWithButter>();
        internal static ItemGroup JacketPotatoWithTunaMayo => GetModdedGDO<ItemGroup, JacketPotatoWithTunaMayo>();
        internal static Item TunaCanOpened => GetModdedGDO<Item, TunaCanOpened>();
        internal static Item TunaCan => GetModdedGDO<Item, TunaCan>();
        internal static Item TunaMayo => GetModdedGDO<Item, TunaMayo>();
        
        // Providers
        internal static Appliance TunaCanProvider => GetModdedGDO<Appliance, TunaCanProvider>();

        // Modded Dishes
        internal static Dish JacketPotatoWithBeansDish => GetModdedGDO<Dish, JacketPotatoWithBeansDish>();

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
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
            
            LogInfo("Done loading asset bundle.");

            // Custom GDOs are now auto registered 
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
        public static void LogInfo(string log) { Debug.Log($"[{MOD_NAME}] " + log); }
        public static void LogWarning(string log) { Debug.LogWarning($"[{MOD_NAME}] " + log); }
        public static void LogError(string log) { Debug.LogError($"[{MOD_NAME}] " + log); }
        public static void LogInfo(object log) { LogInfo(log.ToString()); }
        public static void LogWarning(object log) { LogWarning(log.ToString()); }
        public static void LogError(object log) { LogError(log.ToString()); }
        #endregion
    }
}
