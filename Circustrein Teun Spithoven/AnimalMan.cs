using System.Collections.Generic;
using System.Linq;

namespace Circustrein_Teun_Spithoven
{
    public class AnimalMan
    {
        public Animal TheAnimalThatFits;
        public WagonMan wagonMan;

        public List<Animal> MakeAnimals(int amount)
        {
            if (amount > 0)
            {
                List<Animal> returnList = new List<Animal>();

                for (int i = 0; i < amount; i++)
                {
                    Animal animal = new Animal(i);
                    returnList.Add(animal);
                }

                return returnList;
            }

            return null;
        }

        public Animal FindBiggestCarnivore(List<Animal> animals)
        {
            List<Animal> carnivoresInList = new List<Animal>();
            carnivoresInList = animals.FindAll(x => x.IsCarnivore == true);
            if (carnivoresInList.Count != 0)
            {
                List<Animal> biggestCarnivoreFirst = new List<Animal>();
                biggestCarnivoreFirst = carnivoresInList.OrderByDescending(x => x.Size).ToList();
                Animal biggestCarnivoreInCarnivoreList = biggestCarnivoreFirst.First();

                return biggestCarnivoreInCarnivoreList;
            }
            return null;
        }
    }
}