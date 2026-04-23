using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages.Heroes
{
    public class HeroDetailModel : PageModel
    {
        private readonly PartyService _partyService;

        public HeroDetailModel(PartyService partyService)
        {
            _partyService = partyService;
        }
        public string HeroName { get; set; }
        public AHero Hero { get; set; }

        public void OnGet(string name, int id)
        {
            HeroName = name;
            Hero = _partyService.GetById(id);
            
        }
    }
}
