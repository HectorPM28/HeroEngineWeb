using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models.Interfaces
{
    public interface IAbilityUser
    {
        Dictionary<string, AAbility> Abilities { get; set; }
        int Mana { get; set; }
        int MaxMana { get; set; }
        void AddAbility(AAbility ability);
        void ShowAbilities();
    }
}
