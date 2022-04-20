using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Captain : ICaptain
    {
        private string fullNameField;

        public Captain(string fullname)
        {
            FullName = fullname;
            CombatExperience = 0;
            Vessels = new List<IVessel>();
        }
        public string FullName 
        {
            get
            {
                return fullNameField;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                else
                {
                    fullNameField = value;
                }
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            else
            {
                Vessels.Add(vessel);
            }
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            foreach (var item in Vessels)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
