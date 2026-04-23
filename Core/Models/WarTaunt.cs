using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Wartaunt : AAbility
    {
        public Wartaunt() : base("War Taunt", RandomNumsHelper.GetRandomRarity(), EAbilityType.Attack, 15)
        {
        }
        public override void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero)
        {
            Console.WriteLine(UIConfig.Abilities.WarTaunt);
        }
    }
}
