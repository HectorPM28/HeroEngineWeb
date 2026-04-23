using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages.Heroes
{
    public class CreateRogueModel : PageModel
    {
        private readonly PartyService _partyService;

        public CreateRogueModel(PartyService partyService)
        {
            _partyService = partyService;
        }
        [BindProperty]
        public string RogueName { get; set; }

        public IActionResult OnPostAdd()
        {
            var newRogue = new Rogue(RogueName, Rogue.RogueBaseHp, 1, 1, 5);

            _partyService.Add(newRogue);

            return RedirectToPage("Heroes");
        }
    }
}
