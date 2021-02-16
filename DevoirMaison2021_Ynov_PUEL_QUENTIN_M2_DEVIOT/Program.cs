using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters;
using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes;
using System;
using System.Threading.Tasks;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Character o1 = new Berserker("Toto");
            Character o2 = new Necromancien("tata");
            Character o3 = new Paladin("tata");
            Character o4 = new Zombie("tata");
            Console.WriteLine("Name : {0}",o1.Name);
            Console.WriteLine("Initiative : {0}",o1.Initiative());
            Console.WriteLine("{0}", o1.GetType());
            Console.WriteLine("{0}", o2 is IUndead);
            o3.DealDamage(o4);


        }
    }
}
