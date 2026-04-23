using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages.Heroes
{
    public class CreateMageModel : PageModel
    {
        private readonly PartyService _partyService;

        public CreateMageModel(PartyService partyService)
        {
            _partyService = partyService;
        }
        [BindProperty]
        public string MageName { get; set; }

        public IActionResult OnPostAdd()
        {
            var newMage = new Mage(MageName, Mage.BaseMageHp, 1, 1, 100, 1);

            _partyService.Add(newMage);

            return RedirectToPage("Heroes");
        }
    }
}
