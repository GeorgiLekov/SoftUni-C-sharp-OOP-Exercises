using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string nameField;
        private ICollection<IEquipment> equipmentField;
        private ICollection<IAthlete> athletesField;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipmentField = new List<IEquipment>();
            athletesField = new List<IAthlete>();
        }
        public string Name 
        { 
            get { return nameField; }
            
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                nameField = value;
            } 
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight 
        {
            get
            {
                double result = 0d;
                foreach (var item in Equipment)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        public ICollection<IEquipment> Equipment 
        {
            get
            {
                return equipmentField;
            }
            private set
            {
                equipmentField = value;
            }
        }

        public ICollection<IAthlete> Athletes
        {
            get
            {
                return athletesField;
            }
            private set
            {
                athletesField = value;
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if(Athletes.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");

            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach(var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Name} is a {this.GetType().Name}:");
            if(Athletes.Count == 0)
            {
                result.AppendLine($"Athletes: No athletes");
            }
            else
            {

                result.Append($"Athletes: ");
                int count = 0;
                foreach(var item in Athletes)
                {
                    count++;
                    if(count == Athletes.Count)
                    {
                        result.Append(item.FullName);
                    }
                    else
                    {
                        result.Append($"{item.FullName}, ");
                    }
                }
                result.AppendLine();
            }
            result.AppendLine($"Equipment total count: {Equipment.Count}");
            result.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            bool result = Athletes.Remove(athlete);

            return result;
        }
    }
}
