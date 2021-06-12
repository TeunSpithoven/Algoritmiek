using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Models
{
    public class Animal
    {
        public int Id { get; private set; }
        public bool IsCarnivore { get; private set; }
        public int Size { get; private set; }
        public int Points { get; private set; }

        public Animal(int id, bool isCarnivore, int size, int points)
        {
            Id = id;
            IsCarnivore = isCarnivore;
            Size = size;
            Points = points;
        }

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
            List<Animal> carnivoresInList = animals.FindAll(x => x.IsCarnivore);

            if (carnivoresInList.Count <= 0) return null;

            List<Animal> biggestCarnivoreFirst = carnivoresInList.OrderByDescending(x => x.Size).ToList();
            return biggestCarnivoreFirst.First();
        }

        public static Animal FindBiggestHerbivore(List<Animal> animals)
        {
            List<Animal> herbivoresInList = animals.FindAll(x => !x.IsCarnivore);

            if (herbivoresInList.Count <= 0) return null;

            List<Animal> biggestHerbivoreFirst = herbivoresInList.OrderByDescending(x => x.Size).ToList();
            return biggestHerbivoreFirst.First();
        }

        public static bool CanFitInWagon(Wagon wagon, Animal animal)
        {
            return wagon.Points + animal.Points <= 10;
        }
    }
}
