using Circustrein.Models;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein.Controllers
{
    public class Preservationist
    {
        // The preservationist will compare a wagon and animals, and will find the animal that
        // can fit in the wagon without getting eaten.
        public static Animal FindFittingAnimal(List<Animal> animals, Wagon wagon)
        {
            List<Animal> herbivores = animals.FindAll(x => !x.IsCarnivore);
            Animal wagonCarnivore = AnimalController.FindBiggestCarnivore(wagon.Animals);

            // No animal in the wagon and carnivores left.
            if (animals.Exists(x => x.IsCarnivore) && wagon.Animals.Count == 0)
                return AnimalController.FindBiggestCarnivore(animals);

            // Carnivore is in the wagon
            if (wagon.Animals.Exists(x => x.IsCarnivore))
            {
                // Find bigger herbivores than the carnivore that also fit in the wagon
                List<Animal> fittingHerbivores = herbivores.Where(herbivore =>
                    herbivore.Size > wagonCarnivore.Size && AnimalController.CanFitInWagon(wagon, herbivore)).ToList();
                // No animal(s) found: return null / Animal(s) found: return first animal in list.
                return fittingHerbivores.Count <= 0 ? null : fittingHerbivores.First();
            }

            // Find fitting herbivores
            List<Animal> fittingHerbivoresInList = animals.Where(herbivore =>
                AnimalController.CanFitInWagon(wagon, herbivore)).ToList();
            // Animal(s) found: return first animal / No animal(s) found: return Null
            return fittingHerbivoresInList.Count > 0 ? fittingHerbivoresInList.First() : null;
        }
    }
}