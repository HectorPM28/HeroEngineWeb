using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Minion : AEnemy
    {
        public static int MinionBaseHp = 50;

        public Minion(int hp, int id) : base(hp, id)
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
                return damage;
            }
        }
    }
}
