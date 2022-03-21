using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (command != "End")
            {
                string[] animalInput = command.Split().ToArray();
                string[] food = Console.ReadLine().Split().ToArray();

                Animal current = CreateTheDamnThing(animalInput);

                if (current == null)
                {
                    continue;
                }
                else
                {
                    animals.Add(current);
                }

                current.MakeSound();

                if (current.CanEat(food[0]))
                {
                    int amount = int.Parse(food[1]);
                    current.Eat(amount);
                }

                command = Console.ReadLine();
            }

            foreach(var item in animals)
            {
                Console.WriteLine(item);
            }
        }

        private static Animal CreateTheDamnThing(string[] animalInput)
        {
            string type = animalInput[0];
            string name = animalInput[1];
            double weight = double.Parse(animalInput[2]);

            switch (type)
            {
                case "Hen":
                    double henWings = double.Parse(animalInput[3]);
                    Hen hen = new Hen(name, weight, henWings);
                    return hen;

                case "Owl":
                    double owlWings = double.Parse(animalInput[3]);
                    Owl owl = new Owl(name, weight, owlWings);
                    return owl;

                case "Cat":

                    string caLivingRegion = animalInput[3];
                    string catBreed = animalInput[4];
                    Cat cat = new Cat(name, weight, caLivingRegion, catBreed);
                    return cat;

                case "Tiger":

                    string tigerLivingRegion = animalInput[3];
                    string tigerBreed = animalInput[4];
                    Tiger tiger = new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                    return tiger;

                case "Dog":
                    string livinRegion = animalInput[3];

                    Dog dog = new Dog(name, weight, livinRegion);

                    return dog;
                    
                case "Mouse":
                    string region = animalInput[3];

                    Mouse mouse = new Mouse(name, weight, region);

                    return mouse;
            }

            return null;
        }
    }
}
