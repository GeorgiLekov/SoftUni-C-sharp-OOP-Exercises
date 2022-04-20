using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullNameField;
        private IFormulaOneCar carField;
        public string FullName
        {
            get
            {
                return fullNameField;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPilot);
                }
                else
                {
                    fullNameField = value;
                }
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return carField;
            }

            private set
            {
                if(value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                else
                {
                    carField = value;
                }
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public Pilot(string fullName)
        {
            CanRace = false;

            FullName = fullName;

        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
