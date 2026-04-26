using HeroEngine.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeroEngine.Core.Models.Interfaces
{
    public interface IAbility
    {
        string Name { get; }
        ERarities Rarity { get; }
        EAbilityType Type { get; }
        int Cost { get; }
        void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero);
    }
}
