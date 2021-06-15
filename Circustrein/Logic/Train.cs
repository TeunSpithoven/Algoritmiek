using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Train
    {
        public List<Wagon> Wagons { get; private set; }

        public List<Wagon> WagonFiller(List<Animal> animals)
        {
            int wagonId = 0;
            List<Animal> newAnimals = new List<Animal>(animals);
            List<Wagon> wagons = new();
            Wagon wagon = new(wagonId++);

            while (newAnimals.Count > 0)
            {
                // is er een beest in de lijst die in de wagon past?
                Animal foundAnimal = wagon.FindFittingAnimal(newAnimals);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    AddAnimalToWagon(foundAnimal, wagon, newAnimals);
                    foundAnimal = wagon.FindFittingAnimal(newAnimals);
                }

                // nee nieuwe wagon
                wagons.Add(wagon);
                wagon = new Wagon(wagonId++);
            }
            // Stop
            return wagons;
        }

        public Wagon AddAnimalToWagon(Animal animal, Wagon wagon, List<Animal> newAnimals)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            if (newAnimals == null)
            {
                return wagon;
            }
            newAnimals.RemoveAll(x => x.Id == animal.Id);
            return wagon;
        }
    }
}
