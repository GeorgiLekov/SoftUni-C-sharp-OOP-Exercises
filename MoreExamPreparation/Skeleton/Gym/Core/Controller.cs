using Gym.Core.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Equipment;
using System.Linq;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete fucker;
            IGym temp = gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer")
            {
                fucker = new Boxer(athleteName, motivation, numberOfMedals);
                if(temp.GetType().Name != "BoxingGym")
                {
                    return "The gym is not appropriate.";
                }
            }
            else if(athleteType == "Weightlifter")
            {
                fucker = new Weightlifter(athleteName, motivation, numberOfMedals);
                if(temp.GetType().Name != "WeightliftingGym")
                {
                    return "The gym is not appropriate.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

           // int index = gyms.IndexOf(temp);
            temp.AddAthlete(fucker);
            //gyms[index] = temp;

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                BoxingGloves boxingGloves = new BoxingGloves();
                equipment.Add(boxingGloves);
            }
            else if (equipmentType == "Kettlebell")
            {
                Kettlebell kettlebell = new Kettlebell();
                equipment.Add(kettlebell);
            }
            else
            {
                throw new InvalidOperationException($"Invalid equipment type.");
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if(gymType == "BoxingGym")
            {
                BoxingGym boxingGym = new BoxingGym(gymName);
                gyms.Add(boxingGym);
            }
            else if(gymType == "WeightliftingGym")
            {
                WeightliftingGym weightliftingGym = new WeightliftingGym(gymName);
                gyms.Add(weightliftingGym);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var temp = gyms.FirstOrDefault(x => x.Name == gymName);

            var result = temp.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {result:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            IEquipment item = equipment.FindByType(equipmentType);

            if(item == default)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            gym.AddEquipment(item);
            equipment.Remove(item);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach(var place in gyms)
            {
                result.AppendLine(place.GymInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var temp = gyms.FirstOrDefault(x => x.Name == gymName);

            foreach (var fucker in temp.Athletes)
            {
                fucker.Exercise();
            }

            return $"Exercise athletes: {temp.Athletes.Count}.";
        }
    }
}
