using System.Collections.Generic;
using System.Linq;
using Circustrein.Models;

namespace Circustrein.Controllers
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

        

        public void AddAnimalToWagon(Animal animal, List<Animal> animals, Wagon wagon)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            animals.RemoveAll(x => x.Id == animal.Id);
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
                Animal foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    AddAnimalToWagon(foundAnimal, animals, wagon);
                    foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);
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