using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullNameField;
        private string motivationField;
        private int numberOfMedalsField;
        private int staminaField;


        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;

        }
        public string FullName 
        {
            get { return fullNameField; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                fullNameField = value;
            }
        }

        public string Motivation 
        {
            get { return motivationField; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                motivationField = value;
            }
        }

        public int Stamina
        {
            get
            {
                return staminaField;
            }
            protected set
            {
                staminaField = value;
            }
        }

        public int NumberOfMedals
        {
            get { return numberOfMedalsField; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                numberOfMedalsField = value;
            }
        }

        public abstract void Exercise();
    }
}
