using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using System.Text.Json;

namespace HeroEngine.Services
{
    public class PartyService
    {
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Heroes.json");

        public void SaveHeroes(List<AHero> party)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            string jsonString = JsonSerializer.Serialize(party, options);
            File.WriteAllText(_path, jsonString);
        }
        public List<AHero> GetAll()
        {
            if (!File.Exists(_path))
            {
                var initialParty = new List<AHero>
            {
                new Warrior ("Pepe", Warrior.WarriorBaseHp, 1, 1, 45, "a"),
                new Mage ("Juan", Mage.BaseMageHp, 1, 2, 45, 1),
                new Rogue ("Rodrio", Rogue.RogueBaseHp, 1, 3, 45)
            };
                SaveHeroes(initialParty);
                return initialParty;
            }

            string jsonString = File.ReadAllText(_path);
            if (string.IsNullOrWhiteSpace(jsonString)) return new List<AHero>();

            return JsonSerializer.Deserialize<List<AHero>>(jsonString) ?? new List<AHero>();
        }
        public AHero? GetById(int id) => GetAll().FirstOrDefault(g => g.Id == id);
        public void Add(AHero hero)
        {
            var party = GetAll();

            int nextId = party.Any() ? party.Max(x => x.Id) + 1 : 1;
            hero.Id = nextId;

            party.Add(hero);
            SaveHeroes(party);
        }
        public void Update(AHero hero)
        {
            var party = GetAll();
            var index = party.FindIndex(g => g.Id == hero.Id);
            if (index >= 0)
            {
                party[index] = hero;
                SaveHeroes(party);
            }
        }
        public void Delete(int id)
        {
            var party = GetAll();
            party.RemoveAll(g => g.Id == id);
            SaveHeroes(party);
        }
        /// <summary>
        /// Restarts the list of AHero stats
        /// </summary>
        /// <param name="party">List of AHero whose stats will be restarted</param>
        public void RestartPartyAfterBattle(List<AHero> party)
        {
            foreach (AHero hero in party)
            {
                hero.Hp = hero.MaxHp;
                if (hero is IAbilityUser isUser)
                {
                    isUser.Mana = isUser.MaxMana;
                }
            }
            SaveHeroes(party);
        }
    }
}