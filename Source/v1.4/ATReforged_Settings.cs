using UnityEngine;
using Verse;
using RimWorld;

namespace ATReforged
{
    public class ATReforged_Settings : ModSettings
    {
        // GENERAL SETTINGS

            // Settings for mechanical factions
        public static bool androidFactionsNeverFlee;

        internal void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard
            {
                maxOneColumn = true
            };
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("ATR_AndroidFactionsNeverFlee".Translate(), ref androidFactionsNeverFlee);
            listingStandard.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();

            // Android Factions
            Scribe_Values.Look(ref androidFactionsNeverFlee, "ATR_androidFactionsNeverFlee", false);
        }
    }

}