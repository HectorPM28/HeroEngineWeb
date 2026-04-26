using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Mage : AHero//, IAbilityUser
    {
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public int ArcaneLevel { get; set; }
        public Dictionary<string, AAbility> Abilities { get; set; } = [];
        public static int BaseMageHp = 100;

        public Mage(string name, int hp, int level, int id, int mana, int arcaneLevel) : base(name, hp, level, id)
        {
            MaxMana = mana + level;
            Mana = mana + level;
            ArcaneLevel = arcaneLevel;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Mana: {Mana}/{MaxMana} | ArcaneLevel: {ArcaneLevel}";

        }
        public override int Attack(int damage)
        {
            if (Hp <= 0)
            {
                CantAttack();
                return 0;
            }
            else
            {
                return damage * 2;
            }
        }
        public override void AddAbility(AAbility ability)
        {
            if (Abilities.ContainsKey(ability.Name))
            {
                Console.WriteLine(UIConfig.AbilityError.AbilityRepeated);
                Thread.Sleep(1000);
            }
            else
            {
                Abilities.Add(ability.Name, ability);
            }
        }
        public void ShowAbilities()
        {
            List<AAbility> sortedList = Abilities.Values.OrderByDescending(num => num.Rarity).ToList();

            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"{i}. {sortedList[i].ToString()}");
            }
        }
    }
}
