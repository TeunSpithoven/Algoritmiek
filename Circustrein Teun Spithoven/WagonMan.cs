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

        public void WagonFiller(List<Animal> animals)
        {
            // om hem korter te maken(hopelijk):
            // samenvatting:
            // nieuwe wagon
            // zitten er beesten in de lijst?
            // past er nog een beest bij?
            //nog geen beest in wagon? pleur dan een beest er in!
            // eerst de grootste carnivoren
            // als de carnivoren op zijn door met de herbivoren
            // zit er een carnivoor in de wagon
            // is er een grotere herbivoor?
            // geen carnivoor in de lijst, kijk wat er nog bij kan

            TrainMan train = new TrainMan();
            AnimalMan animalMan = new AnimalMan();
            // nieuwe wagon
            Wagon wagon = NewWagon();

            // zitten er beesten in de lijst?
            while (animals.Count != 0)
            {
                // past er nog een beest bij?
                if (wagon.Points < 10)
                {
                    //nog geen beest in de wagon, doe die er dan een in
                    if (wagon.Animals.Count == 0)
                    {
                        // telkens de grootste carnivoor
                        Animal biggestCarnivore = animalMan.FindBiggestCarnivore(animals);
                        if (biggestCarnivore != null)
                        {
                            if (DoesAnotherAnimalFit(wagon.Points, biggestCarnivore.Points))
                            {
                                AddAnimalToWagon(biggestCarnivore, animals, wagon);
                            }
                            else
                            {
                                train.WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                        // als die op zijn door met herbivoren
                        else
                        {
                            // als het past
                            if (DoesAnotherAnimalFit(wagon.Points, animals.Last().Points))
                            {
                                AddAnimalToWagon(animals.Last(), animals, wagon);
                            }
                        }
                    }

                    // kan er een beest bij die niet opgegeten wordt of iemand op eet?
                    // zit er een carnivoor in de wagon?
                    if (wagon.Animals.Exists(x => x.IsCarnivore == true))
                    {
                        // grootste carnivoor in de lijst
                        Animal biggestCarnivoreInwagon = animalMan.FindBiggestCarnivore(wagon.Animals);

                        // is er een herbivoor die groter is, zo ja voeg toe, zo nee nieuwe wagon
                        Animal biggerHerbivore = animals.Find(x =>
                            x.IsCarnivore == false && x.Size > biggestCarnivoreInwagon.Size);
                        if (biggerHerbivore != null)
                        {
                            // toevoegen aan wagon als het past
                            if (DoesAnotherAnimalFit(wagon.Points, biggerHerbivore.Points))
                            {
                                AddAnimalToWagon(biggerHerbivore, animals, wagon);
                            }
                            // het past niet dus volgende wagon
                            else
                            {
                                train.WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                        // nee geen grotere herbivoor, nieuwe wagon
                        else
                        {
                            train.WagonPrinter(wagon);
                            wagon = NewWagon();
                        }
                    }
                    // er zit geen carnivoor in de lijst!
                    // kijken wat er nog bij kan!
                    else
                    {
                        // als er nog een herbivoor is en er bij past doe die er in
                        List<Animal> herbivoresInList = new List<Animal>();
                        herbivoresInList = (animals.FindAll(x => x.IsCarnivore == false));

                        if (herbivoresInList.Count > 0)
                        {
                            // vind een herbivoor die past
                            int remainingSpace = 10 - wagon.Points;
                            List<Animal> fittingHerbivores = herbivoresInList.FindAll(x => x.Points <= remainingSpace);
                            // als die past voeg die toe
                            if (fittingHerbivores.Count > 0)
                            {
                                AddAnimalToWagon(fittingHerbivores.First(), animals, wagon);
                            }
                            // als die niet past, nieuwe wagon
                            else
                            {
                                train.WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                    }
                }
                // nee geen ruimte, nieuwe wagon
                else
                {
                    train.WagonPrinter(wagon);
                    wagon = NewWagon();
                }
            }

            // print de laatste wagon als er een beest in zit
            if (wagon.Animals.Count > 0)
            {
                train.WagonPrinter(wagon);
            }
        }
    }
}