using HeroEngine.Core.Models;
using HeroEngine.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine.Core.UI
{
    public static class Usables
    {

        /// <summary>
        /// Starts a combat for a list of AHero to fight
        /// </summary>
        /// <param name="party">List of AHero that will fight</param>
        public static void StartCombat(List<AHero> party)
        {
            int count = 0, round = 1;
            List<AEnemy> enemies = new List<AEnemy>(3);

            CreateEnemyTeam(enemies);
            Console.WriteLine(UIConfig.Combat.EnemiesCreated);
            ShowListToSelect(enemies);
            Console.ReadKey();
            Console.Clear();

            do
            {
                if (count >= party.Count) count = 0;
                if (party[count].DeadState)
                {
                    count = (count + 1) % party.Count;
                }
                CombatRound(party, enemies, count, round);
                count = (count + 1) % party.Count;
                round++;
            } while (CheckPartyState(party) && CheckPartyState(enemies));

            Console.WriteLine(CheckPartyState(party) ? UIConfig.Combat.EnemiesDied : UIConfig.Combat.PartyDied);
            CombatStats.ShowBattleStats();
        }

        /// <summary>
        /// Checks if an AHero is alive to be attacked
        /// </summary>
        /// <param name="party">List of Ahero that can be attacked</param>
        /// <param name="num">Index of choosen Ahero</param>
        /// <returns>Same or new index</returns>
        private static int CheckHeroAliveToGetAttacked(List<AHero> party, int num)
        {
            if (!party[num].DeadState)
            {
                return num;
            }

            return RandomNumsHelper.GetRandomHero(party);
        }

        /// <summary>
        /// Starts a combat round
        /// </summary>
        /// <param name="party">List of AHero participating in the round</param>
        /// <param name="enemies">List of AEnemy participating in the round</param>
        /// <param name="num">Index of hero choosen</param>
        /// <param name="round">Number of the round</param>
        private static void CombatRound(List<AHero> party, List<AEnemy> enemies, int num, int round)
        {
            ShowCombatParticipants(party, enemies);

            string textHero = ExecuteHeroAction(party, enemies, num);

            int heroChoosen = GetRandomLivingHeroIndex(party);

            num = CheckEnemyAliveAttack(enemies, num);

            int damageEnemy = RandomNumsHelper.GetRandomDamage();
            party[heroChoosen].GetAttacked(enemies[num].Attack(damageEnemy));

            string textEnemy = $"[{enemies[num].GetType().Name}] > {party[num].Name} -> {damageEnemy}dmg";

            CombatLog.InsertInfoInLog(textHero, textEnemy, round, GetLivingCount(party), GetLivingCount(enemies));
        }

        /// <summary>
        /// Action of the hero in play
        /// </summary>
        /// <param name="party">List where the Hero is</param>
        /// <param name="enemies">List of enemies that may be attacked</param>
        /// <param name="num">Index of hero choosen</param>
        /// <returns></returns>
        private static string ExecuteHeroAction(List<AHero> party, List<AEnemy> enemies, int num)
        {
            Console.WriteLine(UIConfig.Combat.HeroAttacking, party[num].Name);
            int enemyChoosen = IntParse(0, enemies.Count + 1) - 1;

            if (party[num] is IAbilityUser isUser)
            {
                string mageTurn = AbilityUserChoosesTypeAttack(isUser, party, enemies, num, enemyChoosen);
                return mageTurn;
            }

            int damageHero = RandomNumsHelper.GetRandomDamage();
            enemies[enemyChoosen].GetAttacked(party[num].Attack(damageHero));
            CombatStats.CalculateBattleStats(damageHero, num);

            if (enemies[enemyChoosen].DeadState && CombatStats.FirstEnemyDead == null)
            {
                CombatStats.FirstEnemyDead = enemies[enemyChoosen];
            }

            return $"[{party[num].GetType().Name}] {party[num].Name} > {enemies[enemyChoosen]} -> {damageHero}dmg";
        }

        /// <summary>
        /// Changes enemy target if it was gonna attack a dead hero
        /// </summary>
        /// <param name="party"></param>
        /// <returns></returns>
        private static int GetRandomLivingHeroIndex(List<AHero> party)
        {
            var livingIndices = party.Select((h, i) => new { h, i })
                                     .Where(x => !x.h.DeadState)
                                     .Select(x => x.i).ToList();
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, livingIndices.Count);

            return livingIndices[randomIndex];
        }

        /// <summary>
        /// Checks if an enemy is avaliable to attack, if its not, changes attacking enemy.
        /// </summary>
        /// <param name="party">List of attacking AEnemy</param>
        /// <param name="num">Index of choosen enemy</param>
        /// <returns>Same or new index</returns>
        private static int CheckEnemyAliveAttack(List<AEnemy> party, int num)
        {
            if (!party[num].DeadState)
            {
                return num;
            }
            num++;
            if (num > 2)
            {
                num = 0;
            }
            return num;
        }

        /// <summary>
        /// Calculates how many Entities are alive in a List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="party">List of entities</param>
        /// <returns>Returns the number of entities alive</returns>
        private static int GetLivingCount<T>(List<T> party) where T : AEntity
        {
            int alive = 0;
            foreach (T entity in party) if (entity.Hp > 0) alive++;
            return alive;
        }

        /// <summary>
        /// Sees if the List of AEntity is alive or not
        /// </summary>
        /// <typeparam name="T">Can be any value that has a DeadState</typeparam>
        /// <param name="party">List of AEntity that will be checked</param>
        /// <returns>true if any member hp > 0. Else returns false</returns>
        private static bool CheckPartyState<T>(List<T> party) where T : AEntity
        {
            foreach (T entity in party) if (entity.Hp > 0) return true;
            return false;
        }

        /// <summary>
        /// Shows all the participants of a battle
        /// </summary>
        /// <param name="party">List of AHero that will participate</param>
        /// <param name="enemies">List of AEnemy that will participate</param>
        private static void ShowCombatParticipants(List<AHero> party, List<AEnemy> enemies)
        {
            ShowListToSelect(party);
            Console.WriteLine();
            ShowListToSelect(enemies);
        }

        /// <summary>
        /// Restarts the list of AHero stats
        /// </summary>
        /// <param name="party">List of AHero whose stats will be restarted</param>
        public static void RestartPartyAfterBattle(List<AHero> party)
        {
            foreach (AHero hero in party)
            {
                hero.Hp = hero.MaxHp;
                if (hero is IAbilityUser isUser)
                {
                    isUser.Mana = isUser.MaxMana;
                }
            }
        }

        /// <summary>
        /// Asks IAbilityUser what type of attack they wanna do.
        /// </summary>
        /// <param name="isUser">The user of the spell.</param>
        /// <param name="party">The list of AHero that will be affectd if spell is used.</param>
        /// <param name="enemies">The list of AEnemt that will be affected if spell is used</param>
        /// <param name="heroChoosen">The index of the choosen AHero.</param>
        /// <param name="enemyChoosen">The index of the choosen AEnemy.</param>

        private static string AbilityUserChoosesTypeAttack(IAbilityUser isUser, List<AHero> party, List<AEnemy> enemies, int heroChoosen, int enemyChoosen)
        {
            const int minOpt = 0;
            int opt, maxOpt = 2;

            Console.WriteLine(UIConfig.Combat.AskAttack);
            Console.WriteLine(UIConfig.Combat.NormalAttack);
            if (isUser.Abilities.Count > 0)
            {
                maxOpt = 3;
                Console.WriteLine(UIConfig.Combat.AblityAttack);
            }
            opt = IntParse(minOpt, maxOpt);

            switch (opt)
            {
                case 1:
                    int damageHero = RandomNumsHelper.GetRandomDamage();
                    enemies[enemyChoosen].GetAttacked(party[heroChoosen].Attack(damageHero));
                    CombatStats.CalculateBattleStats(damageHero, heroChoosen);
                    return $"[{party[heroChoosen].GetType().Name}] {party[heroChoosen].Name} > {enemies[enemyChoosen]} -> {damageHero}dmg";
                case 2:
                    CastSpell(party[heroChoosen], party, enemies);
                    return $"{party[heroChoosen].Name} used an ability";
                default:
                    return "Mage attacked"
;
            }
        }

        /// <summary>
        /// Makes an AHero execute an ability.
        /// </summary>
        /// <param name="user">The user of the AAbility</param>
        /// <param name="party">The list of AHero that may be affected</param>
        /// <param name="enemies">The list of AEnemy that may be affected</param>
        private static void CastSpell(AHero user, List<AHero> party, List<AEnemy> enemies)
        {
            if (user is IAbilityUser abilityUser)
            {
                List<string> abilityNames = abilityUser.Abilities.Keys.ToList();

                Console.WriteLine(UIConfig.Abilities.ChooseAbility);
                abilityUser.ShowAbilities();

                int selection = IntParse(-1, abilityNames.Count);
                string abilityName = abilityNames[selection];

                AAbility ability = abilityUser.Abilities[abilityName];
                ability.Execute(party, enemies, user);
                abilityUser.Mana -= ability.Cost;
            }
        }

        /// <summary>
        /// Fills a List of AEnemy.
        /// </summary>
        /// <param name="party">An empty list to save the AEnemy</param>
        private static void CreateEnemyTeam(List<AEnemy> enemies)
        {
            for (int i = 0; i < enemies.Capacity; i++)
            {
                enemies.Add(GetRandomEnemy());
            }
        }

        /// <summary>
        /// Generates a random type of AEnemy
        /// </summary>
        /// <returns>Returns an AEnemy</returns>
        private static AEnemy GetRandomEnemy()
        {
            Random rnd = new Random();
            const int minEnemyVal = 0, maxEnemyVal = 4;
            int enemyCreated = rnd.Next(minEnemyVal, maxEnemyVal);

            switch (enemyCreated)
            {
                case 1:
                    return new Minion(Minion.MinionBaseHp);
                case 2:
                    return new Elites(Elites.EliteBaseHp);
                case 3:
                    return new Boss(Boss.BossesHp);
                default:
                    Boss defaultEnemy = new Boss(Boss.BossesHp);
                    return defaultEnemy;
            }
        }
        /// <summary>
        /// Selects and gives an AAbility to a AHero from a list of AHero
        /// </summary>
        /// <param name="party">List of AHero</param>
        public static void AssignAbilityToHero(List<AHero> party)
        {
            const int minAbilityVal = 0, maxAbilityVal = 5;
            int heroSelectedInt, abilitySelectedInt;

            ShowListToSelect(party);
            Console.WriteLine(UIConfig.Abilities.WhoGetsAbility);

            heroSelectedInt = IntParse(0, party.Count + 1) - 1;
            UIConfig.ShowAbilities();
            abilitySelectedInt = IntParse(minAbilityVal, maxAbilityVal) - 1;
            party[heroSelectedInt].AddAbility(SelectAbility(abilitySelectedInt + 1));
        }

        /// <summary>
        /// Show a list of AHero with numbers for selection.
        /// </summary>
        /// <param name="party">The list of AHero</param>
        public static void ShowListToSelect<T>(List<T> party)
        {
            for (int i = 0; i < party.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {party[i].ToString()}");
            }
        }
        /// <summary>
        /// Checks if a string can be converted into an Int and that Int is between values
        /// </summary>
        /// <param name="minVal">Minimum value that the Int can be</param>
        /// <param name="maxVal">Maximum value that the number can be</param>
        /// <returns>Returns an Int that represents the string</returns>
        public static int IntParse(int minVal, int maxVal)
        {
            bool correctOpt = false;
            string num = "";
            do
            {
                num = Console.ReadLine();
                if (int.TryParse(num, out int choosen))
                {
                    if (choosen < maxVal && choosen > minVal)
                    {
                        return choosen;
                    }
                    else
                    {
                        Console.WriteLine(UIConfig.InputError.OutOfBounds);
                    }
                }
                else
                {
                    Console.WriteLine(UIConfig.InputError.IntError);
                }
            } while (!correctOpt);
            return 1;
        }
        /// <summary>
        /// Creates a AAbility depends on the num given
        /// </summary>
        /// <param name="opt">Int that selects the AAbility</param>
        /// <returns>An AAbiilty</returns>
        private static AAbility SelectAbility(int opt)
        {
            switch (opt)
            {
                case 1:
                    return new ThunderSmash();
                case 2:
                    return new SecondWind();
                case 3:
                    return new IronFortress();
                case 4:
                    return new Wartaunt();
                default:
                    return new ThunderSmash();
            }
        }

        /// <summary>
        /// Asks for a name for a AHero
        /// </summary>
        /// <returns>A string that represents the name of the hero</returns>
        private static string NameHero()
        {
            string name;
            Console.WriteLine(UIConfig.Hero.NameHero);
            name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Show a list of AHero with their abilities.
        /// </summary>
        /// <param name="party">The list of AHero</param>
        public static void ShowPartyHeroes(List<AHero> party)
        {
            for (int i = 0; i < party.Count; i++)
            {
                if (party[i] is IAbilityUser isUser)
                {
                    Console.WriteLine($"{i + 1}. {isUser.ToString()}");
                    isUser.ShowAbilities();
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {party[i].ToString()}");
                }
            }
        }
    }
}
