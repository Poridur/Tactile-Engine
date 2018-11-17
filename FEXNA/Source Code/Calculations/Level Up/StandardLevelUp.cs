﻿using System.Linq;
using FEXNA.Calculations.LevelUp.Stats;

namespace FEXNA.Calculations.LevelUp
{
    /// <summary>
    /// Rolls for each stat
    /// </summary>
    class StandardLevelUp : LevelUpProcessor
    {
        public StandardLevelUp(Game_Actor actor, int levelCount = 1)
            : base(actor, levelCount) { }

        protected override LevelUpStats GetLevel(
            int[] growths, int[] gainedStats, int[] currentLevelStats, bool atBaseLevel)
        {
            bool[] cappedStats = GetCappedStats(gainedStats);

            if (atBaseLevel && Constants.Actor.SEMIFIXED_FIRST_LEVEL_UP)
            {
                var stats = new SemifixedLevelUpStats(
                    growths, currentLevelStats, cappedStats);
                return stats;
            }
            else
            {
                if (Constants.Actor.NO_EMPTY_LEVELS)
                {
                    var stats = new NoZeroLevelUpStats(growths, currentLevelStats, cappedStats);
                    return stats;
                }
                else
                {
                    var stats = new LevelUpStats(growths, currentLevelStats, cappedStats);
                    return stats;
                }
            }
        }
    }
}