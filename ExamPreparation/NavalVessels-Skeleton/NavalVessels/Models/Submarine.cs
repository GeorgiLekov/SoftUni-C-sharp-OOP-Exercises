using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200d)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = 200d;
        }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
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

            if (SubmergeMode)
            {
                result.AppendLine(" *Submerge mode: ON");
            }
            else
            {
                result.AppendLine(" *Submerge mode: OFF");
            }
            return result.ToString().TrimEnd();
        }
    }
}
