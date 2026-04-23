using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class ThunderSmash : AAbility
    {
        private int _damage = 75;
        public ThunderSmash() : base("Thunder Smash", RandomNumsHelper.GetRandomRarity(), EAbilityType.Attack, 30)
        {
        }
        public override void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero)
        {
            int newDamage = _damage + (int)Rarity;
            Console.WriteLine(UIConfig.Abilities.ThunderSmash, hero.Name, newDamage);
            enemies.ForEach(e => e.Hp -= newDamage);
        }
    }
}
