using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine.Core.UI
{
    public static class Usables
    {

        /// <summary>
        /// Checks if an AHero is alive to be attacked
        /// </summary>
        /// <param name="party">List of Ahero that can be attacked</param>
        /// <param name="num">Index of choosen Ahero</param>
        /// <returns>Same or new index</returns>
        private static int CheckHeroAliveToGetAttacked(List<AHero> party, int num)
        {
            if (!party[num].DeadState)
            {
                return num;
            }

            return RandomNumsHelper.GetRandomHero(party);
        }

        /// <summary>
        /// Starts an enemy combat round
        /// </summary>
        /// <param name="party">List of AHero participating in the round</param>
        /// <param name="enemies">List of AEnemy participating in the round</param>
        /// <param name="num">Index of hero choosen</param>
        /// <param name="round">Number of the round</param>
        public static AHero EnemyRound(List<AHero> party, List<AEnemy> enemies, int damageEnemy)
        {
            int heroChoosen = GetRandomListIndex(party);

            party[heroChoosen].GetAttacked(enemies[GetRandomListIndex(enemies)].Attack(damageEnemy));

            return party[heroChoosen];
        }

        /// <summary>
        /// Starts an enemy combat round
        /// </summary>
        /// <param name="party">List of AHero participating in the round</param>
        /// <param name="enemies">List of AEnemy participating in the round</param>
        /// <param name="num">Index of hero choosen</param>
        /// <param name="round">Number of the round</param>
        public static void HeroRound(List<AHero> party, AEnemy enemy, int heroDamage)
        {
            int heroChoosen = GetRandomListIndex(party);
            enemy.GetAttacked(party[heroChoosen].Attack(heroDamage));
        }

        /// <summary>
        /// Changes enemy target if it was gonna attack a dead hero
        /// </summary>
        /// <param name="party"></param>
        /// <returns></returns>
        private static int GetRandomListIndex<T>(List<T> party) where T: AEntity
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, party.Count);

            return randomIndex;
        }

        /// <summary>
        /// Calculates how many Entities are alive in a List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="party">List of entities</param>
        /// <returns>Returns the number of entities alive</returns>
        public static int GetLivingCount<T>(List<T> party) where T : AEntity
        {
            int alive = 0;
            foreach (T entity in party) if (entity.Hp > 0) alive++;
            return alive;
        }

        /// <summary>
        /// Sees if the List of AEntity is alive or not
        /// </summary>
        /// <typeparam name="T">Can be any value that has a DeadState</typeparam>
        /// <param name="party">List of AEntity that will be checked</param>
        /// <returns>true if any member hp > 0. Else returns false</returns>
        public static bool CheckPartyState<T>(List<T> party) where T : AEntity
        {
            foreach (T entity in party) if (entity.Hp > 0) return true;
            return false;
        }       

        /// <summary>
        /// Generates a random type of AEnemy
        /// </summary>
        /// <returns>Returns an AEnemy</returns>
        public static AEnemy GetRandomEnemy(int id)
        {
            Random rnd = new Random();
            const int minEnemyVal = 1, maxEnemyVal = 4;
            int enemyCreated = rnd.Next(minEnemyVal, maxEnemyVal);

            switch (enemyCreated)
            {
                case 1:
                    return new Minion(Minion.MinionBaseHp, id);
                case 2:
                    return new Elites(Elites.EliteBaseHp, id);
                case 3:
                    return new Boss(Boss.BossesHp, id);
                default:
                    Boss defaultEnemy = new Boss(Boss.BossesHp, id);
                    return defaultEnemy;
            }
        }
    }
}
