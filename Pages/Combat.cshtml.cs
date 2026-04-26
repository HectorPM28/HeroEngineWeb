using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
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
            var allHeroes = _partyService.GetAll();
            Party = allHeroes.Take(3).ToList();

            Enemies = _enemyService.GetAll();
            if (!Usables.CheckPartyState(Enemies) || !Usables.CheckPartyState(Party))
            {
                Enemies = _enemyService.RestartList();
                _partyService.RestartPartyAfterBattle(allHeroes);
            }
        }
        public IActionResult OnPostAtacar(int idEnemy)
        {
            var allHeroes = _partyService.GetAll();

            for (int i = 1; i < 4; i++)
            {
                Party.Add(_partyService.GetById(i));
            }
            Enemies = _enemyService.GetAll();

            var target = _enemyService.GetById(idEnemy);
            int heroDamage = RandomNumsHelper.GetRandomDamage();

            Usables.HeroRound(Party, target, heroDamage);

            int enemyDamage = RandomNumsHelper.GetRandomDamage();
            var hero = Usables.EnemyRound(Party, Enemies, enemyDamage);
            _partyService.SaveHeroes(allHeroes);

            CombatLog.InsertInfoInLog(hero, target, Usables.GetLivingCount(Party), Usables.GetLivingCount(Enemies), heroDamage, enemyDamage);
            return RedirectToPage();
        }
    }
}
