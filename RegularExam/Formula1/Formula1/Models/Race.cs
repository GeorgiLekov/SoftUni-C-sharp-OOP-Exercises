using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceNameField;
        private int numberOfLapsField;
        public string RaceName 
        {
            get
            {
                return raceNameField;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName);
                }
                else
                {
                    raceNameField = value;
                }
            }
        }

        public int NumberOfLaps 
        {
            get
            {
                return numberOfLapsField;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers);
                }
                else
                {
                    numberOfLapsField = value;
                }
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get; private set; }

        public Race(string raceName, int numberOfLaps)
        {
            TookPlace = false;

            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");

            string temp;
            if (TookPlace)
            {
                temp = "Yes";
            }
            else
            {
                temp = "No";
            }

            result.AppendLine($"Took place: {temp}");

            return result.ToString().TrimEnd();
        }
    }
}
