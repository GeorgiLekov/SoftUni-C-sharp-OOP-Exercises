using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public class Warrior : BaseHero
    {
        const int defaultPower = 100;
        public Warrior(string name)
        {
            Name = name;
            Power = defaultPower;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Warrior - {Name} hit for {Power} damage");
        }
    }
}
