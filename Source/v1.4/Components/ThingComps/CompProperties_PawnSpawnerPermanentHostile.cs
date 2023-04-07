using Verse;

namespace ATReforged
{
    public class CompProperties_PawnSpawnerPermanentHostile : CompProperties_PawnSpawner
    {
        public CompProperties_PawnSpawnerPermanentHostile()
        {
            compClass = typeof(CompPawnSpawnerPermanentHostile);
        }

        public HediffDef hediffDefToSpawnWith;

        public float hediffSeverity = -1f;
    }
}
