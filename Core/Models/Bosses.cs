using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Boss : AEnemy
    {
        public static int BossesHp = 100;

        public Boss(int hp) : base(hp)
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
                return damage * 3;
            }
        }
    }
}
