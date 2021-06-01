using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circustrein.Models;

namespace Circustrein.Controllers
{
    public static class Preservationist
    {
        // This is the "person" organizing what animal goes in what wagon
        // So that the wagons are filled optimally and no animal gets eaten.
        public static bool DoesAnotherAnimalFit(int wagonPoints, int animalPoints)
        {
            return wagonPoints + animalPoints <= 10;
        }

        public static Animal FindFittingAnimal(List<Animal> animals, Wagon wagon)
        {
            AnimalController animalController = new();
            List<Animal> herbivores = animals.FindAll(x => !x.IsCarnivore);
            Animal wagonCarnivore = animalController.FindBiggestCarnivore(wagon.Animals);

            // als er nog carnivoren zijn en er geen dier in de wagon zit, voeg de grootste carnivoor toe
            if (animals.Exists(x => x.IsCarnivore) && wagon.Animals.Count == 0)
                return animalController.FindBiggestCarnivore(animals);

                // als er een carnivoor in de wagon zit
            if (wagon.Animals.Exists(x => x.IsCarnivore))
            {
                // grootste carnivoor in de wagon

                // welke dieren in de lijst passen er bij
                List<Animal> fittingHerbivores = new();
                foreach (var herbivore in herbivores)
                {
                    if (herbivore.Size > wagonCarnivore.Size && DoesAnotherAnimalFit(wagon.Points, herbivore.Points))
                        fittingHerbivores.Add(herbivore);
                }

                return fittingHerbivores.Count <= 0 ? null : fittingHerbivores.First();
                // toevoegen aan wagon als het past
            }
            // er zit geen carnivoor in de wagon!

            // als er nog een herbivoor is en er bij past doe die er in
            List<Animal> herbivoresInList = animals.FindAll(x => x!.IsCarnivore);

            if (herbivoresInList.Count <= 0) return null;

            // vind de herbivoren die passen
            List<Animal> fittingHerbivoresInList = new();
            foreach (var herbivore in herbivoresInList)
            {
                if (DoesAnotherAnimalFit(wagon.Points, herbivore.Points))
                {
                    fittingHerbivoresInList.Add(herbivore);
                }
            }

            // return een passende herbivoor als die er is
            return fittingHerbivoresInList.Count > 0 ? fittingHerbivoresInList.First() : null;
        }
    }
}
