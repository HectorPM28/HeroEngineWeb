using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace HeroEngine.Core.Models
{
    public class Elites : AEnemy
    {
        public static int EliteBaseHp = 75;
        public Elites(int hp) : base(hp)
        {
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
    }
}
