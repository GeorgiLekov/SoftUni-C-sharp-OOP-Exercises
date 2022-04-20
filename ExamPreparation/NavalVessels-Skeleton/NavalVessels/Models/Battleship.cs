using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300d)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = 300d;
        }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
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

            if (SonarMode)
            {
                result.AppendLine($" *Sonar mode: ON");
            }
            else
            {
                result.AppendLine($" *Sonar mode: OFF");
            }

            return result.ToString().TrimEnd();
        }
    }
}
