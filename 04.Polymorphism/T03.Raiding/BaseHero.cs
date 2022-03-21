using System;
using System.Collections.Generic;
using System.Text;

namespace T03.Raiding
{
    public class BaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public virtual void CastAbility()
        {

        }
    }
}
