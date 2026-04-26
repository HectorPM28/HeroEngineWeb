using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class ExtrasModel : PageModel
    {
        private readonly PartyService _partyDervice;
        public ExtrasModel(PartyService partyService)
        {
            _partyDervice = partyService;
        }
        public List<AHero> Party { get; set; } = new();
        public List<Mage> Mages { get; set; } = new();
        public List<Warrior> Warriors { get; set; } = new();
        public List<Rogue> Rogue { get; set; } = new();
        public List<AHero> BestHeroes { get; set; } = new();
        public Dictionary<string, int> TopAbilities { get; set; }
        public void OnGet()
        {
            Party = _partyDervice.GetAll();
            Mages = Party.OfType<Mage>().ToList();
            Warriors = Party.OfType<Warrior>().ToList();
            Rogue = Party.OfType<Rogue>().ToList();
            BestHeroes = Party.OrderBy(x => x.Id).Take(3).ToList();

            TopAbilities = Party
                .OfType<IAbilityUser>()
                .SelectMany(h => h.Abilities.Values)
                .GroupBy(a => a.Name)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
        }
    }
}
