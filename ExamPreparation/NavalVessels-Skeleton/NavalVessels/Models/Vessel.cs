using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string nameField;
        private ICaptain captainField;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            Targets = new List<string>();
            captainField = null;
        }
        public string Name 
        {
            get
            {
                return nameField;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                else
                {
                    nameField = value;
                }
            }
        }

        public ICaptain Captain
        {
            get 
            {
                return captainField;
            }
            set
            {
                if (value != null)
                {
                    captainField = value;
                }
                else
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if(target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);

            if (target.Captain != null)
            {
                target.Captain.IncreaseCombatExperience();
            }
            
            if(this.Captain != null)
            {
                this.Captain.IncreaseCombatExperience();
            }
            
        }

        public virtual void RepairVessel()
        {

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            result.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            result.AppendLine($" *Speed: {this.Speed} knots");

            if (this.Targets.Count == 0)
            {
                result.AppendLine($" *Targets: None");
            }
            else
            {
                result.AppendLine($" *Targets: {string.Join(", ", Targets)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
