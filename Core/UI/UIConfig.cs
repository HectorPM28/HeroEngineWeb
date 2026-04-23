using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.UI
{
    public static class UIConfig
    {
        public static void ShowHeroes()
        {
            Console.WriteLine("1. Warrior\n2. Mage\n3. Rogue");
            Console.WriteLine("Select hero");
        }
        public static void ShowMenu()
        {
            Console.WriteLine("What do you wanna do?");
            Console.WriteLine("1. See party");
            Console.WriteLine("2. Assign abilities");
            Console.WriteLine("3. Fight enemies");
            Console.WriteLine("4. Finish adventure");
        }
        public static void ShowAbilities()
        {
            Console.WriteLine("1. Thunder Smash");
            Console.WriteLine("2. Secon Wind");
            Console.WriteLine("3. Iron Fortress");
            Console.WriteLine("4. War Taunt");
            Console.WriteLine("Select an ability");
        }
        public static class Abilities
        {
            public const string ThunderSmash = "{0} channels the storm! {1} lightning damage to all enemies!";
            public const string IronFortress = "{0} builds a wall to help their commrades. +{1} to all heroes";
            public const string SecondWind = "{0} guides the wind. The party heals {1} hp.";
            public const string WarTaunt = "RAAAAH im an useless ability";
            public const string ChooseAbility = "Choose an ability: ";
            public const string WhoGetsAbility = "Who will be granted an ability";
            public const string CantUseAbilities = "{0} cannot learn abilities.";
        }
        public static class Combat
        {
            public const string AskAttack = "How do you want to attack";
            public const string NormalAttack = "1. Normal attack";
            public const string AblityAttack = "2. Use ability";
            public const string EnemiesCreated = "Enemies found!";
            public const string PartyDied = "Your party died";
            public const string EnemiesDied = "Your enemies died";
            public const string HeroAttacking = "{0} is attacking. Choose an enemy to attack";
            public const string CantAttack = "{0} can't attack because they're dead";
            public const string CantGetattacked = "{0} can't get attacked because they're dead";
            public const string GetAttacked = "{0} gets attacked. Loses {1} hp";
        }
        public static class AbilityError
        {
            public const string AbilityRepeated = "This hero already has this ability";
        }
        public static class InputError
        {
            public const string IntError = "Insert a number!";
            public const string OutOfBounds = "Choose between the options";
        }
        public static class Hero
        {
            public const string WarScream = "Give a war scream to your warrior";
            public const string NameHero = "Give a name to the hero";
        }
        public static class Menu
        {
            public const string PressToContinue = "Press anything to continue..";
        }
    }
}
