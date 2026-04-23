using HeroEngine.Core.Models;

namespace HeroEngine.Services
{
    public class AbilityService
    {
        private readonly List<AAbility> _abilities = new()
        {
            new ThunderSmash (),
            new SecondWind (),
            new IronFortress (),
            new Wartaunt ()
        };

        public List<AAbility> GetAll() => _abilities;
        public AAbility? GetById(int id) => _abilities.FirstOrDefault(g => g.Id == id);
    }
}
