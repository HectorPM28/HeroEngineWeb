using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeroEngine.Core.Models
{ 
    public abstract class AAbility : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ERarities Rarity { get; set; }

        public EAbilityType Type { get; set; }

        public int Cost { get; set; }
        public AAbility(string name, ERarities rarity, EAbilityType type, int cost, int id)
        {
            Name = name;
            Rarity = rarity;
            Type = type;
            Cost = cost + (int)rarity;
            Id = id;
        }

        /// <summary>
        /// Executes an AAbility
        /// </summary>
        /// <param name="party">List of AHero that may be affected</param>
        /// <param name="enemies">List of AEnemy that may be affected</param>
        /// <param name="hero">Hero that executes the ability</param>
        public abstract void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero);
        public override string ToString()
        {
            return $"[{Rarity}] {Name} | Type: {Type} | Cost: {Cost}";
        }
    }
}
