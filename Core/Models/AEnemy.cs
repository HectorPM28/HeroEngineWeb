using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public abstract class AEnemy : AEntity
    {
        protected AEnemy(int hp, int id) : base(hp, id)
        {
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] HP: {Hp}/{MaxHp}";
        }
        public override void GetAttacked(int damage)
        {
            if (Hp <= 0)
            {
                CantGetAttacked();
            }
            else
            {
                Console.WriteLine(UIConfig.Combat.GetAttacked, GetType().Name, damage);
                Hp -= damage;
            }
        }
    }
}