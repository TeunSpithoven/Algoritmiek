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

        public Animal()
        {

        }

        public Animal FindBiggestCarnivore(List<Animal> animals)
        {
            List<Animal> carnivoresInList = animals.FindAll(x => x.IsCarnivore);

            if (carnivoresInList.Count <= 0) return null;

            List<Animal> biggestCarnivoreFirst = carnivoresInList.OrderByDescending(x => x.Size).ToList();
            return biggestCarnivoreFirst.First();
        }

        public Animal FindBiggestHerbivore(List<Animal> animals)
        {
            List<Animal> herbivoresInList = animals.FindAll(x => !x.IsCarnivore);

            if (herbivoresInList.Count <= 0) return null;

            List<Animal> biggestHerbivoreFirst = herbivoresInList.OrderByDescending(x => x.Size).ToList();
            return biggestHerbivoreFirst.First();
        }
    }
}
