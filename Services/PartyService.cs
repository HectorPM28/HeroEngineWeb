using HeroEngine.Core.Models;

namespace HeroEngine.Services
{
    public class PartyService
    {
        private readonly List<AHero> _party = new()
        {
            new Warrior ("Pepe", Warrior.WarriorBaseHp, 1, 1, 45, "a"),
            new Mage ("Juan", Mage.BaseMageHp, 1, 2, 45, 1),
            new Rogue ("Rodrio", Rogue.RogueBaseHp, 1, 3, 45)
        };
        private int _nextId = 4;

        public List<AHero> GetAll() => _party;
        public AHero? GetById(int id) => _party.FirstOrDefault(g => g.Id == id);
        public void Add(AHero hero)
        {            
            hero.Id = _nextId++;
            _party.Add(hero);
        }
        public void Update(AHero game)
        {
            var index = _party.FindIndex(g => g.Id == game.Id);
            if (index >= 0) _party[index] = game;
        }
        public void Delete(int id) => _party.RemoveAll(g => g.Id == id);
    }
}