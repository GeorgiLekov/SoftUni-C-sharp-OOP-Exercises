using System;

namespace T03.Raiding
{
    public class Rogue : BaseHero
    {
        const int defaultPower = 80;
        public Rogue(string name)
        {
            Name = name;
            Power = defaultPower;
        }

        public override void CastAbility()
        {
            Console.WriteLine($"Rogue - {Name} hit for {Power} damage");
        }
    }
}
