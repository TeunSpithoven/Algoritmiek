using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic
{
    public class Wagon
    {
        public int Id { get; private set; }
        public List<Animal> Animals { get; set; }
        public int Points { get; set; }

        public Wagon(int id)
        {
            Id = id;
            var animals = new List<Animal>();
            Animals = animals;
            Points = 0;
        }

        // This function will find the the animal that fits in the given wagon
        // So no animal will get eaten and the animals will fit in the least amount of wagons.
        public Animal AddFittingAnimal(List<Animal> animals)
        {
            Animal returnAnimal = new Animal();
            // No animal in the wagon and carnivores left.
            if (animals.Exists(x => x.IsCarnivore) && Animals.Count == 0)
            {
                returnAnimal = returnAnimal.FindBiggestCarnivore(animals);
                AddAnimal(returnAnimal);
                return returnAnimal;
            }

            // Carnivore is in the wagon
            if (Animals.Exists(x=> x.IsCarnivore))
            {
                // Find animals that fit and don't eat or get eaten by other animals
                List<Animal> fittingAnimals = animals.Where(animal =>
                    !animal.IsCarnivore && !AnimalGetsEaten(animal) && AnimalFits(animal)).ToList();
                // No animal(s) found: return null / Animal(s) found: return first animal in list.
                if (fittingAnimals.Count <= 0) return null;
                returnAnimal = returnAnimal.FindBiggestHerbivore(fittingAnimals);
                AddAnimal(returnAnimal);
                return returnAnimal;
            }

            // Find fitting herbivores
            List<Animal> fittingHerbivores = animals.Where(animal =>
                !animal.IsCarnivore && AnimalFits(animal) && !AnimalGetsEaten(animal)).ToList();

            if (fittingHerbivores.Count <= 0) return null;
            var biggestHerbivoreFirst = fittingHerbivores.OrderByDescending(x => x.Size);
            returnAnimal = biggestHerbivoreFirst.First();
            AddAnimal(returnAnimal);
            return returnAnimal;
        }

        private bool AnimalFits(Animal animal)
        {
            return Points + animal.Points <= 10;
        }

        private bool AnimalGetsEaten(Animal animal)
        {
            List<Animal> wagonCarnivores = Animals.FindAll(x => x.IsCarnivore);
            if (wagonCarnivores.Count > 1)
                throw new InvalidDataException("Multiple carnivores found in one wagon!");
            
            return wagonCarnivores.Count == 1 && wagonCarnivores[0].Size >= animal.Size;
        }

        private Wagon AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Points += animal.Points;
            return this;
        }
    }
}