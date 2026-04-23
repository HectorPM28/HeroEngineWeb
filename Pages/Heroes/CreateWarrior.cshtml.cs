using HeroEngine.Core.Models;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages.Heroes
{
    public class CreateWarriorModel : PageModel
    {
        private readonly PartyService _partyService;

        public CreateWarriorModel(PartyService partyService)
        {
            _partyService = partyService;
        }
        [BindProperty]
        public string WarriorName { get; set; }
        [BindProperty]
        public string WarScream { get; set; }

        public IActionResult OnPostAdd()
        {
            var newWarrior = new Warrior(WarriorName, Warrior.WarriorBaseHp, 1, 1, 45, WarScream);

            _partyService.Add(newWarrior);

            return RedirectToPage("Heroes");
        }
    }
}
