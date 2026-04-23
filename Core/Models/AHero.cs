using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;
using static HeroEngine.Core.UI.UIConfig;

namespace HeroEngine.Core.Models
{
    public abstract class AHero : AEntity
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public AHero(string name, int hp, int level, int id) : base(hp)
        {
            Level = level;
            MaxHp += level;
            Hp += level;
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Level: {Level} | HP: {Hp}/{MaxHp}";
        }
        public virtual void AddAbility(AAbility ability)
        {
            Console.WriteLine(UIConfig.Abilities.CantUseAbilities, Name);
            Thread.Sleep(1000);
        }
        protected virtual void CantAttack()
        {
            Console.WriteLine(UIConfig.Combat.CantAttack, Name);
        }
        protected virtual void CantGetAttacked()
        {
            Console.WriteLine(UIConfig.Combat.CantGetattacked, Name);
        }
        public override void GetAttacked(int damage)
        {
            if (Hp < 0)
            {
                CantGetAttacked();
            }
            else
            {
                Console.WriteLine(UIConfig.Combat.GetAttacked, Name, damage);
                Hp -= damage;
            }
        }
    }
}
