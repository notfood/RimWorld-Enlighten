using System;
using System.Linq;

using Verse;
using RimWorld;

namespace Enlighten
{
	public class Def : Verse.Def
	{
		public HediffDef hediff;

		public float glowMin;
		public float glowMax;

		public override void PostLoad () {
			// no hashes
		}

		public override void ResolveReferences ()
		{
			var organicStandardDef = DefDatabase<HediffGiverSetDef>.GetNamed("OrganicStandard");

			if (organicStandardDef != null && hediff != null)
			{
				organicStandardDef.hediffGivers.Add (new HediffGiver_Enlighten () { glowMin = glowMin, glowMax = glowMax, hediff = hediff });
			}

		}

	}
}

