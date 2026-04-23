using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.UI
{
    public static class RandomNumsHelper
    {
        private static Random Rnd = new Random();

        /// <summary>
        /// Generates a random rarity for an ability
        /// </summary>
        /// <returns>Returns a rarity for an avility</returns>
        public static ERarities GetRandomRarity()
        {
            int MinimumRarity = 1, MaximumRarity = 5, randomNum = Rnd.Next(MinimumRarity, MaximumRarity);

            switch (randomNum)
            {
                case 1:
                    return ERarities.Common;
                case 2:
                    return ERarities.Rare;
                case 3:
                    return ERarities.Epic;
                case 4:
                    return ERarities.Legendary;
                default:
                    return ERarities.Common;
            }
        }

        /// <summary>
        /// Generates a random damage of a d20
        /// </summary>
        /// <returns>Returns an Int for a damage</returns>
        public static int GetRandomDamage()
        {
            int minDamage = 1, maxDamage = 21, damage = Rnd.Next(minDamage, maxDamage);
            return damage;
        }

        /// <summary>
        /// Chooses a random AHero from a list
        /// </summary>
        /// <param name="party"></param>
        /// <returns>Returns index from AHero</returns>
        public static int GetRandomHero(List<AHero> party)
        {
            int minHeroVal = 0, choosenHero = Rnd.Next(minHeroVal, party.Count);
            return choosenHero;
        }
    }
}
