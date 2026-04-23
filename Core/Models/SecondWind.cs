using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class SecondWind : AAbility
    {
        private int _heal = 30;
        public SecondWind() : base("Second Wind", RandomNumsHelper.GetRandomRarity(), EAbilityType.Attack, 10, 2)
        {
        }
        public override void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero)
        {
            int newHeal = _heal + (int)Rarity;
            Console.WriteLine(UIConfig.Abilities.SecondWind, hero.Name, newHeal);
            party.ForEach(e => e.Hp += newHeal);
        }
    }
}
