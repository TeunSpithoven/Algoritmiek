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
        private List<Animal> _animals;
        private int _wagonId;

        public List<Wagon> WagonFiller(List<Animal> animals)
        {
            _animals = new List<Animal>(animals);
            List<Wagon> wagons = new();
            Wagon wagon = new(_wagonId++);

            while (_animals.Count > 0)
            {
                // is er een beest in de lijst die in de wagon past?
                Animal foundAnimal = wagon.FindFittingAnimal(_animals);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    AddAnimalToWagon(foundAnimal, wagon);
                    foundAnimal = wagon.FindFittingAnimal(_animals);
                }

                // nee nieuwe wagon
                wagons.Add(wagon);
                wagon = new Wagon(_wagonId++);
            }
            // Stop
            return wagons;
        }

        public Wagon AddAnimalToWagon(Animal animal, Wagon wagon)
        {
            wagon.Animals.Add(animal);
            wagon.Points += animal.Points;
            if (_animals == null) return wagon;
            _animals.RemoveAll(x => x.Id == animal.Id);
            return wagon;
        }
    }
}
