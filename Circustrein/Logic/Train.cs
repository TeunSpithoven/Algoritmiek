using System.Collections.Generic;

namespace Logic
{
    public class Train
    {
        public List<Wagon> Wagons { get; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public List<Wagon> WagonFiller(List<Animal> animals)
        {
            int wagonId = 0;
            List<Animal> newAnimals = new List<Animal>(animals);
            List<Wagon> wagons = new();
            Wagon wagon = new(wagonId++);

            while (newAnimals.Count > 0)
            {
                // is er een beest in de lijst die in de wagon past?
                Animal foundAnimal = wagon.AddFittingAnimal(newAnimals);
                while (foundAnimal != null)
                {
                    // ja: doe het beest die er bij kan in de wagon
                    newAnimals.RemoveAll(x => x.Id == foundAnimal.Id);
                    foundAnimal = wagon.AddFittingAnimal(newAnimals);
                }

                // while (wagon.FindFittingAnimal(animals) != null)
                // {
                //     newAnimals.RemoveAll(x => x.Id == foundAnimal.Id);
                // }

                // nee nieuwe wagon
                wagons.Add(wagon);
                wagon = new Wagon(wagonId++);
            }
            // Stop
            return wagons;
        }
    }
}
