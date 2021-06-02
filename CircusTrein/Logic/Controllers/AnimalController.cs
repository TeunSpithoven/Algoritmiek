using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein.Models;

namespace Circustrein.Controllers
{
    public class AnimalController
    {
        public static List<Animal> MakeRandomAnimals(int amount)
        {
            if (amount > 0)
            {
                List<Animal> returnList = new();

                for (int i = 0; i < amount; i++)
                {
                    Random random = new();

                    int randomIsCarnivore = random.Next(2);
                    bool isCarnivore = Convert.ToBoolean(randomIsCarnivore);

                    int randomSize = random.Next(3);

                    int points = randomSize switch
                    {
                        0 => 1,
                        1 => 3,
                        2 => 5,
                        _ => 0
                    };

                    Animal animal = new(i, isCarnivore, randomSize, points);
                    returnList.Add(animal);
                }

                return returnList;
            }

            return null;
        }

        public static Animal FindBiggestCarnivore(List<Animal> animals)
        {
            List<Animal> carnivoresInList = animals.FindAll(x => x.IsCarnivore == true);

            if (carnivoresInList.Count != 0)
            {
                List<Animal> biggestCarnivoreFirst = carnivoresInList.OrderByDescending(x => x.Size).ToList();
                Animal biggestCarnivoreInCarnivoreList = biggestCarnivoreFirst.First();
                return biggestCarnivoreInCarnivoreList;
            }

            return null;
        }

        public static bool CanFitInWagon(Wagon wagon, Animal animal)
        {
            return wagon.Points + animal.Points <= 10;
        }
    }
}