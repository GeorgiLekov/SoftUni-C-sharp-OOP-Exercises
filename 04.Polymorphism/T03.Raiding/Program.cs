using System;
using System.Collections.Generic;

namespace T03.Raiding
{
    public class Program
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {
                    case ("Druid"):
                        Druid druid = new Druid(name);
                        heroes.Add(druid);
                        break;
                    case ("Paladin"):
                        Paladin paladin = new Paladin(name);
                        heroes.Add(paladin);
                        break;
                    case ("Rogue"):
                        Rogue rogue = new Rogue(name);
                        heroes.Add(rogue);
                        break;
                    case ("Warrior"):
                        Warrior warrior = new Warrior(name);
                        heroes.Add(warrior);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            long bossPower = long.Parse(Console.ReadLine());
            long raidPower = 0;

            foreach(var hero in heroes)
            {
                hero.CastAbility();
                raidPower += hero.Power;
            }

            if (raidPower < bossPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
