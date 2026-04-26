using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.UI
{
    public static class CombatLog
    {
        static string proyectoRuta = Directory.GetCurrentDirectory();

        public static string path = Path.Combine(proyectoRuta, "Data", "BattleLog.txt");

        public static void InsertInfoInLog(AHero textHero, AEnemy textEnemy, int heroAlive, int enemyAlive, int heroDamage, int enemyDamage)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("==================================================");
                    sw.WriteLine($"BATTLE LOG - Time {DateTime.Now}");
                    sw.WriteLine("==================================================");
                    sw.WriteLine($"{textEnemy} loses {heroDamage}hp");
                    sw.WriteLine($"{textHero.Name} loses {enemyDamage}hp");
                    sw.WriteLine("--------------------------------------------------");
                    sw.WriteLine($"Remaining enemies: {enemyAlive} | Heroes standing: {heroAlive}");
                    sw.WriteLine("==================================================");
                    sw.WriteLine();
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"No s'ha trobat el fitxer");
            }
        }
    }
}
