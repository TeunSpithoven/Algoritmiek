using System.Collections.Generic;
using System.Linq;
using Logic.Controllers;

namespace Logic.Models
{
    public class Wagon
    {
        private static int _id;
        public int Id { get; private set; }
        public List<Animal> Animals { get; set; }
        public int Points { get; set; }

        public Wagon()
        {
            Id = _id;
            _id++;
            var animals = new List<Animal>();
            Animals = animals;
            Points = 0;
        }

        // This function will find the the animal that fits in the given wagon
        // So no animal will get eaten and the animals will fit in the least amount of wagons.
        public static Animal FindFittingAnimal(List<Animal> animals, Wagon wagon)
        {
            // No animal in the wagon and carnivores left.
            if (animals.Exists(x => x.IsCarnivore) && wagon.Animals.Count == 0)
                return Animal.FindBiggestCarnivore(animals);

            // Carnivore is in the wagon
            if (wagon.Animals.Exists(x => x.IsCarnivore))
            {
                List<Animal> herbivores = animals.FindAll(x => !x.IsCarnivore);
                Animal wagonCarnivore = Animal.FindBiggestCarnivore(wagon.Animals);
                // Find bigger herbivores than the carnivore that also fit in the wagon
                List<Animal> fittingHerbivores = herbivores.Where(herbivore =>
                    herbivore.Size > wagonCarnivore.Size && Animal.CanFitInWagon(wagon, herbivore)).ToList();
                // No animal(s) found: return null / Animal(s) found: return first animal in list.
                return fittingHerbivores.Count <= 0 ? null : fittingHerbivores.First();
            }
            List<Animal> herbivoresInList = animals.FindAll(x => !x.IsCarnivore);
            // Find fitting herbivores

            List<Animal> fittingHerbivoresInList = new();

            foreach (Animal herbivore in animals)
            {
                if (Animal.CanFitInWagon(wagon, herbivore))
                    fittingHerbivoresInList.Add(herbivore);
            }

            // List<Animal> fittingHerbivoresInList = herbivoresInList.FindAll(herbivore =>
            //     Animal.CanFitInWagon(wagon, herbivore));

            // Animal(s) found: return biggest animal / No animal(s) found: return Null

            // HOE VEEL RUIMTE IS ER NOG OVER EN IS ER EEN DIER DIE DAAR IN PAST?

            var biggestHerbivoreFirst = fittingHerbivoresInList.OrderBy(x => x.Size);
            return fittingHerbivoresInList.Count <= 0 ? null : biggestHerbivoreFirst.Last();
        }

        public static Wagon AddAnimalToWagon(Animal animal, List<Animal> animals, Wagon wagon)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            animals.RemoveAll(x => x.Id == animal.Id);
            return wagon;
        }
    }
}
