using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.UI
{
    public static class CombatLog
    {
        static string path = @"..\..\..\files\BattleLog.txt";

        public static void InsertInfoInLog(string textHero, string textEnemy, int round, int heroAlive, int enemyAlive)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("==================================================");
                    sw.WriteLine($"BATTLE LOG - Round {round}");
                    sw.WriteLine("==================================================");
                    sw.WriteLine(textHero);
                    sw.WriteLine(textEnemy);
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
