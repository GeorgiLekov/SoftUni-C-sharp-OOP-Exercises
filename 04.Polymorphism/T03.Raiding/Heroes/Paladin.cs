using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public class Paladin : BaseHero
    {
        const int defaultPower = 100;
        public Paladin(string name)
        {
            Name = name;
            Power = defaultPower;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Paladin - {Name} healed for {Power}");
        }
    }
}
