using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();


            foreach (var item in players)
            {
                if (item.GetType().Name == "Barbarian")
                {
                    barbarians.Add(item);
                }
                else if (item.GetType().Name == "Knight")
                {
                    knights.Add(item);
                }
            }

            int knightsInitialCount = knights.Count;
            int barbariansInitialCount = barbarians.Count;

            while(barbarians.Count > 0 && knights.Count > 0)
            {
                for (int i = 0; i < knights.Count; i++)
                {
                    for (int j = 0; j < barbarians.Count; j++)
                    {
                        barbarians[j].TakeDamage(knights[i].Weapon.DoDamage());
                        if (barbarians[j].Health <= 0)
                        {
                            barbarians.RemoveAt(j);
                            j--;
                        }
                    }
                }

                for (int i = 0; i < barbarians.Count; i++)
                {
                    for (int j = 0; j < knights.Count; j++)
                    {
                        knights[j].TakeDamage(barbarians[i].Weapon.DoDamage());
                        if (knights[j].Health <= 0)
                        {
                            knights.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }

            if (barbarians.Count == 0)
            {
                return $"The knights took {knightsInitialCount - knights.Count} casualties but won the battle.";
            }

            return $"The barbarians took {barbariansInitialCount - barbarians.Count} casualties but won the battle.";
        }
    }
}
