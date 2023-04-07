using HarmonyLib;
using System.Reflection;
using Verse;
using UnityEngine;
using RimWorld;

namespace ATReforged
{
    public class ATReforged : Mod
    {
        public static ATReforged_Settings settings;
        public static ATReforged ModSingleton { get; private set; }

        public ATReforged(ModContentPack content) : base(content)
        {
            ModSingleton = this;
            new Harmony("ATReforged").PatchAll(Assembly.GetExecutingAssembly());
        }
        
        // Handles the localization for the mod's name in the list of mods in the mod settings page.
        public override string SettingsCategory()
        {
            return "ATR_ModTitle".Translate();
        }

        // Handles actually displaying this mod's settings.
        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoSettingsWindowContents(inRect);
            base.DoSettingsWindowContents(inRect);
        }
    }

    [StaticConstructorOnStartup]
    public static class ATReforged_PostInit
    {
        static ATReforged_PostInit()
        {
            ATReforged.settings = ATReforged.ModSingleton.GetSettings<ATReforged_Settings>();

            // Patch android factions based on the appropriate settings.
            DefDatabase<FactionDef>.GetNamedSilentFail("ATR_AndroidUnion").autoFlee = ATReforged_Settings.androidFactionsNeverFlee;
            DefDatabase<FactionDef>.GetNamedSilentFail("ATR_MechanicalMarauders").autoFlee = ATReforged_Settings.androidFactionsNeverFlee;
        }
    }
}