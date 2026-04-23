using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Rogue : AHero
    {
        public int HiddenDagger { get; set; }
        private int Multiplier = 2;
        public static int RogueBaseHp = 120;
        public Rogue(string name, int hp, int level, int id, int hiddenDagger) : base(name, hp, level, id)
        {
            HiddenDagger = hiddenDagger;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Multiplier: {Multiplier}";

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
                return damage * Multiplier;
            }
        }
    }
}
