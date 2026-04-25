using HeroEngine.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public abstract class AEntity
    {
        public int Id { get; set; }
        public int MaxHp { get; set; } = 100;
        public bool DeadState { get; private set; } = false;
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = (value < 0) ? 0 : value;
                if (value < 0)
                {
                    _hp = 0;
                }
                else if (_hp > MaxHp)
                {
                    _hp = MaxHp;
                }
                else
                {
                    _hp = value;
                }

                if (_hp == 0)
                {
                    DeadState = true;
                }
                else
                {
                    DeadState = false;
                }
            }
        }
        private int _hp;
        public AEntity(int hp, int id)
        {
            MaxHp = hp;
            _hp = hp;
            Id = id;
        }
        public abstract int Attack(int damage);
        public abstract void GetAttacked(int damage);
        protected virtual void CantAttack()
        {
            Console.WriteLine(UIConfig.Combat.CantAttack, GetType().Name);
        }
        protected virtual void CantGetAttacked()
        {
            Console.WriteLine(UIConfig.Combat.CantGetattacked, GetType().Name);
        }
    }
}
