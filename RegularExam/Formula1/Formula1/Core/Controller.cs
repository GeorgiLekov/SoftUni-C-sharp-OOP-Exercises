using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var temp = pilotRepository.FindByName(pilotName);
            if (temp == null || temp.Car != null) // potential problem
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }

            var carTemp = carRepository.FindByName(carModel);

            if(carModel == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            Pilot pilot = new Pilot(temp.FullName);
            pilot.AddCar(carTemp);

            pilotRepository.Remove(temp);
            pilotRepository.Add(pilot);

            return $"Pilot { pilotName } will drive a {carTemp.GetType().Name} { carTemp.Model } car.";

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var temp = raceRepository.FindByName(raceName);

            if(temp == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }

            var pilotTemp = pilotRepository.FindByName(pilotFullName);

            if(pilotTemp == null || pilotTemp.CanRace == false || temp.Pilots == null||temp.Pilots.Contains(pilotTemp)) // potential problem
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }

            Race race = (Race)temp;

            race.AddPilot(pilotTemp);

            raceRepository.Remove(temp);
            raceRepository.Add(race);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var temp = raceRepository.FindByName(model);

            if (temp != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }

            if( type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }

            if(type == "Ferrari")
            {
                var car = new Ferrari(model, horsepower, engineDisplacement);
                carRepository.Add(car);
            }
            else
            {
                var car = new Williams(model, horsepower, engineDisplacement);
                carRepository.Add(car);
            }

            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot temp = pilotRepository.FindByName(fullName);

            if(temp != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            Pilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);

            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var temp = raceRepository.FindByName(raceName);

            if (temp != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }

            Race race = new Race(raceName,numberOfLaps);
            raceRepository.Add(race);

            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);

            if(race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }

            if(race.Pilots == null || race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }

            if(race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }

            List<double> scores = new List<double>();

            foreach(var item in race.Pilots)
            {
                scores.Add(item.Car.RaceScoreCalculator(race.NumberOfLaps));
            }

            scores = scores.OrderByDescending(x => x).ToList();
            List<Pilot> threeWinners = new List<Pilot>();

            for(int i = 0; i < 3; i++)
            {
                foreach(var item in race.Pilots)
                {
                    if(scores[i] == item.Car.RaceScoreCalculator(race.NumberOfLaps))
                    {
                        Pilot pilot = (Pilot)item;
                        threeWinners.Add(pilot);
                    }
                }
            }

            race.TookPlace = true;
            var increaseWinner = race.Pilots.FirstOrDefault(x => x == threeWinners[0]);
            increaseWinner.WinRace();

            return $"Pilot {threeWinners[0].FullName} wins the {race.RaceName} race.{Environment.NewLine}Pilot {threeWinners[1].FullName} is second in the {raceName} race.{Environment.NewLine}Pilot {threeWinners[2].FullName} is third in the {raceName}race.";

        }
    }
}
