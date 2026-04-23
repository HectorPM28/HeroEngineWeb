using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.UI
{
    public static class CombatStats
    {
        public static AEnemy FirstEnemyDead;
        public static int TotalDamage = 0;
        public static List<int> partyDamage = new List<int>();

        public static void CalculateBattleStats(int damage, int heroDealer)
        {
            TotalDamage += damage;
            partyDamage[heroDealer] += damage;
        }

        private static int GetBestHeroIndex()
        {
            int recordTotal = -1;
            int indiceDelMejor = 0;

            for (int i = 0; i < partyDamage.Count; i++)
            {
                if (partyDamage[i] > recordTotal)
                {
                    recordTotal = partyDamage[i];
                    indiceDelMejor = i;
                }
            }
            return indiceDelMejor;
        }
        public static void ShowBattleStats()
        {
            Console.WriteLine($"Total damage: {TotalDamage}");
            Console.WriteLine($"Index of best hero in battle: {GetBestHeroIndex()}");
            Console.WriteLine($"First enemy dead: {FirstEnemyDead}");
            RestartBattleStats();
        }
        private static void RestartBattleStats()
        {
            FirstEnemyDead = null;
            TotalDamage = 0;
            partyDamage.ForEach(e => e = 0);
        }
    }
}
