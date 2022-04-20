using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var capTemp = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if(capTemp == default)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            var vesTemp = vessels.FindByName(selectedVesselName);

            if(vesTemp == default)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            else if(vesTemp.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vesTemp.Captain = capTemp;
            captains.Remove(capTemp);
            capTemp.AddVessel(vesTemp);
            captains.Add(capTemp);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = vessels.FindByName(attackingVesselName);
            var defender = vessels.FindByName(defendingVesselName);

            if(attacker == default)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            else if(defender == default)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attacker.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            else if (defender.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attacker.Attack(defender);

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            var temp = captains.FirstOrDefault(x => x.FullName == captainFullName);

            return temp.Report();
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);

            var temp = captains.FirstOrDefault(x => x.FullName == fullName);
            if (temp != default)
            {
                return $"Captain {fullName} is already hired.";
            }

            captains.Add(captain);

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;
            var temp = vessels.FindByName(name);

            if (temp != default)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }

            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";

        }

        public string ServiceVessel(string vesselName)
        {
            var temp = vessels.FindByName(vesselName);

            if(temp == default)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            temp.RepairVessel();

            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var temp = vessels.FindByName(vesselName);

            if(temp == default)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if(temp.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)vessels.FindByName(vesselName);
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else if (temp.GetType().Name == "Submarine")
            {
                Submarine submarine = (Submarine)vessels.FindByName(vesselName);
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            return null;
        }

        public string VesselReport(string vesselName)
        {
            var temp = vessels.FindByName(vesselName);

            return temp.ToString();
        }
    }
}
