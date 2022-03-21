using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public class Druid : BaseHero
    {
        const int defaultPower = 80;
        public Druid(string name)
        {
            Name = name;
            Power = defaultPower;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Druid - {Name} healed for {Power}");
        }
    }
}
