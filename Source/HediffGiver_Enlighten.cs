using System;

using RimWorld;
using Verse;

namespace Enlighten
{
	public class HediffGiver_Enlighten : HediffGiver
	{
		public float glowMin;
		public float glowMax;

		public override void OnIntervalPassed (Pawn pawn, Hediff cause)
		{
			if (!pawn.Spawned) {
				return;
			}

			if (!pawn.RaceProps.Humanlike) {
				return;
			}

			if (!RestUtility.Awake (pawn)) {
				return;
			}

			var glow = pawn.Map.glowGrid.GameGlowAt (pawn.Position);

			var firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef (this.hediff);

			if (glow >= glowMin && glow <= glowMax) {
				if (firstHediffOfDef == null) {
					TryApply (pawn);
				}
			} else if (firstHediffOfDef != null) {
				pawn.health.RemoveHediff(firstHediffOfDef);
			}
		}
	}

}

