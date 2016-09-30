using System;

using RimWorld;
using Verse;

namespace Enlighten
{
	public class HediffGiver_Enlighten : HediffGiver
	{
		public float glowMin;
		public float glowMax;

		public override bool CheckGiveEverySecond (Pawn pawn)
		{
			if (!pawn.Spawned) {
				return false;
			}

			if (!pawn.RaceProps.Humanlike) {
				return false;
			}

			if (!RestUtility.Awake (pawn)) {
				return false;
			}

			float glow = Find.GlowGrid.GameGlowAt (pawn.Position);

			Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef (this.hediff);

			if (glow >= glowMin && glow <= glowMax) {
				if (firstHediffOfDef == null) {
					TryApply (pawn);
				}
			} else if (firstHediffOfDef != null) {
				pawn.health.RemoveHediff(firstHediffOfDef);
			}

			return false;
		}
	}

}

