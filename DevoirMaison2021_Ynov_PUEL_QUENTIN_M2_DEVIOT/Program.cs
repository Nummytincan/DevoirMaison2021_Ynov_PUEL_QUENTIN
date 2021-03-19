using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters;
using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes;
using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    class Program
    {
        static FightManager fightManager;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            List<Character> characters = new List<Character>
            {
                new Berserker("Toto"),
                new Necromancien("tata"),
                new Paladin("tutu"),
                new Zombie("titi"),
                new Robot("R"),
                new Pretre("P")
            };
            fightManager = new FightManager(characters);
            fightManager.StartCombat();

            Console.ReadLine();



        }
    }
}
