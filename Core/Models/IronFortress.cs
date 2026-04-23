using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class IronFortress : AAbility
    {
        private int _defense = 40;
        public IronFortress() : base("Iron Fortress", RandomNumsHelper.GetRandomRarity(), EAbilityType.Defense, 20, 3)
        {
        }
        public override void Execute(List<AHero> party, List<AEnemy> enemies, AHero hero)
        {
            int newDefense = _defense + (int)Rarity;
            Console.WriteLine(UIConfig.Abilities.IronFortress, hero.Name, newDefense);
            party.ForEach(e => {
                if (e is Warrior warrior)
                {
                    warrior.Armor += newDefense;
                }
            });
        }
    }
}
