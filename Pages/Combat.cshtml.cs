using HeroEngine.Core.Models;
using HeroEngine.Core.UI;
using HeroEngine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class CombatModel : PageModel
    {
        private readonly PartyService _partyService;
        private readonly EnemiesService _enemyService;

        public CombatModel(PartyService partyService, EnemiesService enemyService)
        {
            _partyService = partyService;
            _enemyService = enemyService;
        }

        public List<AHero> Party { get; set; } = new();
        public List<AEnemy> Enemies { get; set; } = new();

        public void OnGet()
        {
            for(int i = 1; i < 4; i++)
            {
                Party.Add(_partyService.GetById(i));
            }
            Enemies = _enemyService.GetAll();
            if (!Usables.CheckPartyState(Enemies) || !Usables.CheckPartyState(Party))
            {
                Enemies = _enemyService.RestartList();
                Usables.RestartPartyAfterBattle(Party);
            }
        }
        public IActionResult OnPostAtacar(int idEnemy)
        {
            for (int i = 1; i < 4; i++)
            {
                Party.Add(_partyService.GetById(i));
            }
            Enemies = _enemyService.GetAll();
            var target = _enemyService.GetById(idEnemy);
            target.Hp -= RandomNumsHelper.GetRandomDamage();
            Usables.EnemyRound(Party, Enemies);
            return RedirectToPage();
        }
    }
}
