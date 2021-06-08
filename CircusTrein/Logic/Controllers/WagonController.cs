using System.Collections.Generic;
using Logic.Models;

namespace Logic.Controllers
{
    public class WagonController
    {
        private int _id = 1;

        public Wagon NewWagon()
        {
            Wagon returnWagon = new(_id);
            _id++;
            return returnWagon;
        }

        #pragma warning disable CA1822 // Mark members as static
        public void AddAnimalToWagon(Animal animal, List<Animal> animals, Wagon wagon)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            animals.RemoveAll(x => x.Id == animal.Id);
        }

        public List<Wagon> WagonFiller(List<Animal> animals)
        {
            List<Wagon> wagons = new();
            Wagon wagon = NewWagon();

            while (animals.Count > 0)
            {
                // is er een beest in de lijst die in de wagon past?
                Animal foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    AddAnimalToWagon(foundAnimal, animals, wagon);
                    foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);
                }

                // nee nieuwe wagon
                wagons.Add(wagon);
                wagon = NewWagon();
            }
            // Stop
            return wagons;
        }
    }
}