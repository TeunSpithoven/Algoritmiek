using System.Collections.Generic;
using System.Linq;

namespace Circustrein_Teun_Spithoven
{
    public class WagonMan
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
            AnimalMan animalMan = new AnimalMan();
            // als er geen dier in de wagon zit voeg er dan een toe
            if (wagon.Animals.Count == 0)
            {
                return animals.Last();
            }

            // als er een carnivoor in de wagon zit
            if (wagon.Animals.Exists(x => x.IsCarnivore == true))
            {
                // grootste carnivoor in de wagon
                Animal biggestCarnivoreInwagon = animalMan.FindBiggestCarnivore(wagon.Animals);

                // is er in de lijst een herbivoor die niet wordt opgegeten
                Animal biggerHerbivore =
                    animals.Find(x => x.IsCarnivore == false && x.Size > biggestCarnivoreInwagon.Size);
                if (biggerHerbivore != null)
                {
                    // toevoegen aan wagon als het past
                    if (DoesAnotherAnimalFit(wagon.Points, biggerHerbivore.Points))
                    {
                        return biggerHerbivore;
                    }
                }
            }
            // er zit geen carnivoor in de lijst!
            else
            {
                // als er nog een herbivoor is en er bij past doe die er in
                List<Animal> herbivoresInList = new List<Animal>();
                herbivoresInList = (animals.FindAll(x => x.IsCarnivore == false));

                if (herbivoresInList.Count > 0)
                {
                    // vind de herbivoren die passen
                    List<Animal> fittingHerbivores = new List<Animal>();
                    foreach (var herbivore in herbivoresInList)
                    {
                        if (DoesAnotherAnimalFit(wagon.Points, herbivore.Points))
                        {
                            fittingHerbivores.Add(herbivore);
                        }
                    }

                    // return een passende herbivoor als die er is
                    if (fittingHerbivores.Count > 0)
                    {
                        return fittingHerbivores.First();
                    }
                }
            }

            return null;
        }

        public void WagonFiller(List<Animal> animals)
        {
            // Start
            TrainMan trainMan = new TrainMan();

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
                trainMan.WagonPrinter(wagon);
                wagon = NewWagon();
            }

            // Stop
        }
    }
}