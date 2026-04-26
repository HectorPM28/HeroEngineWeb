using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class IndexModel : PageModel
    {

        private readonly PartyService _partyService;

        public IndexModel(PartyService partyService)
        {
            _partyService = partyService;
        }

        public int HeroCount { get; set; }
        public List<AHero> LastHeroes { get; set; }

        public void OnGet()
        {
            var allHeroes = _partyService.GetAll();

            HeroCount = allHeroes.Count;

            // 2. Tomamos solo los últimos 3 o 4 para el resumen
            LastHeroes = allHeroes.TakeLast(4).Reverse().ToList();
        }
    }
}