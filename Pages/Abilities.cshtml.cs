using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class AbilitiesModel : PageModel
    {
        private readonly PartyService _service;
        public AbilitiesModel(PartyService service) => _service = service;
        public List<AHero> Party { get; set; } = new();
        public void OnGet()
        {
            Party = _service.GetAll().Where(s => s is IAbilityUser abilityUser).ToList();
        }
    }
}
