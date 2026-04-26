using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Enums;
using HeroEngine.Core.Models.Interfaces;
using HeroEngine.Services;

namespace HeroEngine.Core.UI
{
    public class HeroAnalytics
    {
        private readonly PartyService _partyService;

        public HeroAnalytics(PartyService partyService)
        {
            _partyService = partyService;
        }

        public List<AHero> GetTopHeroesByLevel(int n)
        {
            var list = _partyService.GetAll();
            List<AHero> sortedList = list.OrderBy(x => x.Level).Take(n).ToList();
            return sortedList;
        }
        public List<AAbility> GetAbilitiesByRarity(ERarities rarity)
        {
            var heroes = _partyService.GetAll();

            List<AAbility> abilities = heroes.OfType<IAbilityUser>().SelectMany(x => x.Abilities.Values).Where(ability => ability.Rarity == rarity).ToList();
            return abilities;
        }
        public List<AHero> GetHeroesWithAbilityCount(int min)
        {
            var heroes = _partyService.GetAll();

            List<AHero> heroeWithMinAbility = heroes.OfType<IAbilityUser>().Where(x => x.Abilities.Count >= min).Cast<AHero>().ToList();
            return heroeWithMinAbility;
        }
        public List<AHero> SearchHeroesByName(string pattern)
        {
            var heroes = _partyService.GetAll();

            List<AHero> heroByName = heroes.Where(x => x.Name == pattern).ToList();

            return heroByName;
        }
    }
}
