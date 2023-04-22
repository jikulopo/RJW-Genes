﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RJW_Genes
{
    public class ThoughtWorker_QueenPresent_Social : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
        {
            if (!p.RaceProps.Humanlike)
                return (ThoughtState) false;

            if (!other.RaceProps.Humanlike)
                return (ThoughtState) false;

            if (!RelationsUtility.PawnsKnowEachOther(p, other))
                return (ThoughtState) false;

            // Only check if they are spawned 
            if (!p.Spawned || !other.Spawned)
            {
                return (ThoughtState)false;
            }

            if (GeneUtility.HasGeneNullCheck(p, GeneDefOf.rjw_genes_zealous_loyalty) && HiveUtility.QueensOnMap() == 1)
            {
                return (ThoughtState) HiveUtility.IsAdultQueen(other);
            }

            return (ThoughtState)false;
        }
    }
}
