using Verse;
using RimWorld;

namespace ATReforged
{
    public class CompPawnSpawnerPermanentHostile : CompPawnSpawner
    {
        public new CompProperties_PawnSpawnerPermanentHostile Props
        {
            get
            {
                return props as CompProperties_PawnSpawnerPermanentHostile;
            }
        }

        // Take the pawn that was generated and spawned from the base class and add a few features to it.
        public override Pawn SpawnPawn()
        {
            Pawn pawn = base.SpawnPawn();

            pawn.SetFactionDirect(Faction.OfAncientsHostile);
            pawn.mindState.mentalStateHandler.TryStartMentalState(ATR_MentalStateDefOf.ATR_MentalState_Exterminator, transitionSilently: true);
            
            if (Props.hediffDefToSpawnWith != null)
            {
                Hediff hediff = HediffMaker.MakeHediff(Props.hediffDefToSpawnWith, pawn, null);
                if (Props.hediffSeverity != -1f)
                {
                    hediff.Severity = Props.hediffSeverity;
                }
                pawn.health.AddHediff(hediff, null, null);
            }

            return pawn;
        }
    }
}