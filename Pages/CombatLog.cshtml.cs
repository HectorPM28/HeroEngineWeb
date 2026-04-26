using HeroEngine.Core.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Pages
{
    public class CombatLogModel : PageModel
    {
        private string _line;
        public List<String> Text { get; set; } = new();
        public void OnGet()
        {
            try
            {
                using StreamReader sr = new StreamReader(CombatLog.path);
                while ((_line = sr.ReadLine()) != null)
                {
                    Text.Add(_line);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"No s'ha trobat el fitxer");
            }
        }
    }
}
