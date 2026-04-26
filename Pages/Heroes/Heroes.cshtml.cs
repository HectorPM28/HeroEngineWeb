using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages.Heroes
{
    public class HeroesModel : PageModel
    {
        private readonly PartyService _service;
        public HeroesModel(PartyService service) => _service = service;

        public List<AHero> Party { get; set; } = new();
        public void OnGet()
        {            
            Party = _service.GetAll();
        }
    }
}
