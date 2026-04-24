using HeroEngine.Core.Models;
using HeroEngine.Core.UI;

namespace HeroEngine.Services
{
    public class EnemiesService
    {
        private readonly List<AEnemy> _enemies = new()
        {
            Usables.GetRandomEnemy(1),
            Usables.GetRandomEnemy(2),
            Usables.GetRandomEnemy(3)
        };
        public List<AEnemy> RestartList()
        {
            _enemies.Clear();
            for(int i = 1; i < 4; i++)
            {
                _enemies.Add(Usables.GetRandomEnemy(i));
            }
            return _enemies;
        }
        public List<AEnemy> GetAll() => _enemies;
        public AEnemy? GetById(int id) => _enemies.FirstOrDefault(g => g.Id == id);

    }
}
