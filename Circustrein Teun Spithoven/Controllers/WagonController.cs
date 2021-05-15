using Circustrein_Teun_Spithoven.Models;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein_Teun_Spithoven.Controllers
{
    public class WagonController
    {
        private int _id = 1;

        public Wagon NewWagon()
        {
            Wagon returnWagon = new Wagon(_id);
            _id++;
            return returnWagon;
        }

        public bool DoesAnotherAnimalFit(int wagonPoints, int animalPoints)
        {
            if (wagonPoints + animalPoints <= 10)
            {
                return true;
            }

            return false;
        }

        public void AddAnimalToWagon(Animal animal, List<Animal> animals, Wagon wagon)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            animals.RemoveAll(x => x.Id == animal.Id);
        }

        public Animal FindFittingAnimal(List<Animal> animals, Wagon wagon)
        {
            AnimalController animalController = new AnimalController();
            List<Animal> herbivores = animals.FindAll(x => x.IsCarnivore == false);
            Animal wagonCarnivore = animalController.FindBiggestCarnivore(wagon.Animals);

            // als er nog carnivoren zijn en er geen dier in de wagon zit, voeg de grootste carnivoor toe
            if (animals.Exists(x => x.IsCarnivore == true) && wagon.Animals.Count == 0)
            {
                return animalController.FindBiggestCarnivore(animals);
            }
            // als er een carnivoor in de wagon zit
            if (wagon.Animals.Exists(x => x.IsCarnivore == true))
            {
                // grootste carnivoor in de wagon

                // welke dieren in de lijst passen er bij
                List<Animal> fittingHerbivores = new();
                foreach (var herbivore in herbivores)
                {
                    if (herbivore.Size > wagonCarnivore.Size && DoesAnotherAnimalFit(wagon.Points, herbivore.Points))
                        fittingHerbivores.Add(herbivore);
                }

                if (fittingHerbivores.Count <= 0) return null;
                // toevoegen aan wagon als het past
                return fittingHerbivores.First();
            }
            // er zit geen carnivoor in de wagon!

            // als er nog een herbivoor is en er bij past doe die er in
            List<Animal> herbivoresInList = animals.FindAll(x => x.IsCarnivore == false);

            if (herbivoresInList.Count <= 0) return null;

            // vind de herbivoren die passen
            List<Animal> fittingHerbivoresInList = new List<Animal>();
            foreach (var herbivore in herbivoresInList)
            {
                if (DoesAnotherAnimalFit(wagon.Points, herbivore.Points))
                {
                    fittingHerbivoresInList.Add(herbivore);
                }
            }

            // return een passende herbivoor als die er is
            if (fittingHerbivoresInList.Count > 0)
            {
                return fittingHerbivoresInList.First();
            }

            return null;
        }

        public List<Wagon> WagonFiller(List<Animal> animals)
        {
            // Start
            TrainController trainMan = new TrainController();
            List<Wagon> returnList = new();

            // nieuwe wagon
            Wagon wagon = NewWagon();

            // is er een beest in de lijst
            while (animals.Count > 0)
            {
                // is er een beest in de lijst die in de wagon past?
                Animal foundAnimal = FindFittingAnimal(animals, wagon);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    AddAnimalToWagon(foundAnimal, animals, wagon);
                    foundAnimal = FindFittingAnimal(animals, wagon);
                }

                // nee nieuwe wagon
                returnList.Add(wagon);
                wagon = NewWagon();
            }
            // Stop
            return returnList;
        }
    }
}