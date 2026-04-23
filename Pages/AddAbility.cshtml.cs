using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class AddAbilityModel : PageModel
    {
        private readonly AbilityService _serviceAbility;
        private readonly PartyService _serviceParty;
        public AddAbilityModel(AbilityService service, PartyService partyService)
        {
            _serviceAbility = service;
            _serviceParty = partyService;
        }

        public List<AAbility> Abilities { get; set; } = new();
        public IAbilityUser Hero { get; set; }
        public void OnGet(int id)
        {
            Abilities = _serviceAbility.GetAll();
        }
        public IActionResult OnPostAdd(int idAbility, int idHero)
        {
            Hero = _serviceParty.GetById(idHero) as IAbilityUser;

            Hero.AddAbility(_serviceAbility.GetById(idAbility));
            return RedirectToPage("/Heroes/Heroes");
        }
    }
}
