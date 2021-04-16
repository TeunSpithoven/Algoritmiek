using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein_Teun_Spithoven
{
    public class WagonMan
    {
        private int _id = 1;

        public Wagon NewWagon()
        {
            List<Animal> animals = new List<Animal>();
            Wagon returnWagon = new Wagon(_id, animals);
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

        public void WagonFiller(List<Animal> animals)
        {
            AnimalMan animalMan = new AnimalMan();
            // nieuwe wagon
            Wagon wagon = NewWagon();

            // zitten er beesten in de lijst?
            while (animals.Count != 0)
            {
                // past er nog een beest bij?
                if (wagon.Points < 10)
                {
                    //nog geen beest? pleur dan een beest er in!
                    if (wagon.Animals.Count == 0)
                    {
                        // telkens de grootste carnivoor
                        Animal biggestCarnivore = animalMan.FindBiggestCarnivore(animals);
                        if (biggestCarnivore != null)
                        {
                            if (DoesAnotherAnimalFit(wagon.Points, biggestCarnivore.Points))
                            {
                                wagon.Animals.Add(biggestCarnivore);
                                wagon.Points += biggestCarnivore.Points;
                                animals.RemoveAll(x => x.Id == biggestCarnivore.Id);
                            }
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                        // als die op zijn door met herbivoren
                        else
                        {
                            // als het past
                            if (DoesAnotherAnimalFit(wagon.Points, animals.Last().Points))
                            {
                                wagon.Animals.Add(animals.Last());
                                wagon.Points += animals.Last().Points;
                                animals.Remove(animals.Last());
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
                        Animal biggerHerbivore = animals.Find(x => x.IsCarnivore == false && x.Size > biggestCarnivoreInwagon.Size);
                        if (biggerHerbivore != null)
                        {
                            // toevoegen aan wagon als het past
                            if (DoesAnotherAnimalFit(wagon.Points, biggerHerbivore.Points))
                            {
                                wagon.Animals.Add(biggerHerbivore);
                                wagon.Points += biggerHerbivore.Points;
                                // verwijderen uit lijst waar id matcht
                                animals.RemoveAll(x => x.Id == biggerHerbivore.Id);
                            }
                            // het past niet dus volgende wagon
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                        // nee geen grotere herbivoor, nieuwe wagon
                        else
                        {
                            WagonPrinter(wagon);
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

                        if (herbivoresInList != null)
                        {
                            // vind een herbivoor die past
                            int remainingSpace = 10 - wagon.Points;
                            List<Animal> fittingHerbivores = herbivoresInList.FindAll(x => x.Points <= remainingSpace);
                            // als die past voeg die toe
                            if (DoesAnotherAnimalFit(wagon.Points, fittingHerbivores[0].Points))
                            {
                                wagon.Animals.Add(fittingHerbivores.First());
                                wagon.Points += fittingHerbivores.First().Points;
                                // verwijderen uit lijst waar id matcht
                                animals.RemoveAll(x => x.Id == fittingHerbivores.First().Id);
                            }
                            // als die niet past, nieuwe wagon
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = NewWagon();
                            }
                        }
                        // geen herbivoren meer, nieuwe wagon
                        else
                        {
                            WagonPrinter(wagon);
                            wagon = NewWagon();
                        }

                        // zo niet, doe een kleinere carnivoor in als dat kan
                    }
                }
                // nee geen ruimte, nieuwe wagon
                else
                {
                    WagonPrinter(wagon);
                    wagon = NewWagon();
                }
            }
            // print de laatste wagon als er een beest in zit
            if (wagon.Animals.Count > 0)
            {
                WagonPrinter(wagon);
            }
        }

        public void WagonPrinter(Wagon wagon)
        {
            if (wagon.Id < 10)
            {
                Console.WriteLine($"                                       -----{wagon.Id}-----");
            }
            else if (wagon.Id < 100)
            {
                Console.WriteLine($"                                       -----{wagon.Id}----");
            }
            else if (wagon.Id < 1000)
            {
                Console.WriteLine($"                                       ----{wagon.Id}----");
            }
            else if (wagon.Id < 10000)
            {
                Console.WriteLine($"                                       ----{wagon.Id}---");
            }
            else if (wagon.Id < 100000)
            {
                Console.WriteLine($"                                       ---{wagon.Id}---");
            }

            foreach (var animal in wagon.Animals)
            {
                // print de bijbehorende eetgewoonte
                if (animal.IsCarnivore == true)
                {
                    Console.WriteLine($"                                       |{Enum.IsCarnivore.Carnivore}|");
                }
                else
                {
                    Console.WriteLine($"                                       |{Enum.IsCarnivore.Herbivore}|");
                }

                // print de bijbehorende grootte
                if (animal.Size == 0)
                {
                    Console.WriteLine($"                                       |  {Enum.Sizes.Small}  |");
                }
                else if (animal.Size == 1)
                {
                    Console.WriteLine($"                                       | {Enum.Sizes.Medium}  |");
                }
                else
                {
                    Console.WriteLine($"                                       |  {Enum.Sizes.Large}  |");
                }
                Console.WriteLine($"                                       |         |");
            }

            if (wagon.Points < 10)
            {
                Console.WriteLine($"                                       ---0{wagon.Points}pts---");
            }
            else
            {
                Console.WriteLine($"                                       ---{wagon.Points}pts---");
            }
            Console.WriteLine("                                            |     ");
        }
    }
}