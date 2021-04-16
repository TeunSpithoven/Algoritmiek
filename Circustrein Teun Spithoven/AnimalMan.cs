using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein_Teun_Spithoven
{
    public class AnimalMan
    {
        public Animal TheAnimalThatFits;
        public WagonMan wagonMan;

        public List<Animal> MakeAnimals(int amount)
        {
            List<Animal> returnList = new List<Animal>();

            for (int i = 0; i < amount; i++)
            {
                Animal animal = new Animal(i);
                returnList.Add(animal);
            }

            return returnList;
        }

        public void WagonFiller(List<Animal> animals)
        {
            wagonMan = new WagonMan();
            // nieuwe wagon
            Wagon wagon = wagonMan.NewWagon();

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
                        Animal biggestCarnivore = FindBiggestCarnivore(animals);
                        if (biggestCarnivore != null)
                        {
                            if (wagonMan.DoesAnotherAnimalFit(wagon.Points, biggestCarnivore.Points))
                            {
                                wagon.Animals.Add(biggestCarnivore);
                                wagon.Points += biggestCarnivore.Points;
                                animals.RemoveAll(x => x.Id == biggestCarnivore.Id);
                            }
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = wagonMan.NewWagon();
                            }
                        }
                        // als die op zijn door met herbivoren
                        else
                        {
                            if (wagonMan.DoesAnotherAnimalFit(wagon.Points, animals.Last().Points))
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
                        // wat is de grootste carnivoor in de wagon
                        List<Animal> carnivoresInWagon = new List<Animal>();
                        carnivoresInWagon = (wagon.Animals.FindAll(x => x.IsCarnivore == true));
                        List<Animal> biggestCarnivoreFirst = new List<Animal>();
                        biggestCarnivoreFirst = carnivoresInWagon.OrderByDescending(x => x.Size).ToList();
                        Animal biggestCarnivoreInwagon = biggestCarnivoreFirst[0];

                        // is er een herbivoor die groter is, zo ja voeg toe, zo nee nieuwe wagon
                        Animal biggerHerbivore = animals.Find(x => x.IsCarnivore == false && x.Size > biggestCarnivoreInwagon.Size);
                        if (biggerHerbivore != null)
                        {
                            // toevoegen aan wagon als het past
                            if (wagonMan.DoesAnotherAnimalFit(wagon.Points, biggerHerbivore.Points))
                            {
                                wagon.Animals.Add(biggerHerbivore);
                                wagon.Points += biggerHerbivore.Points;
                                // verwijderen uit lijst waar id matcht
                                animals.RemoveAll(x => x.Id == biggerHerbivore.Id);
                            }
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = wagonMan.NewWagon();
                            }
                        }
                        else
                        {
                            WagonPrinter(wagon);
                            wagon = wagonMan.NewWagon();
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
                            int remainingSpace = 10 - wagon.Points;
                            List<Animal> fittingHerbivores = herbivoresInList.FindAll(x => x.Points <= remainingSpace);
                            if (wagonMan.DoesAnotherAnimalFit(wagon.Points, fittingHerbivores[0].Points))
                            {
                                wagon.Animals.Add(fittingHerbivores[0]);
                                wagon.Points += fittingHerbivores[0].Points;
                                // verwijderen uit lijst waar id matcht
                                animals.RemoveAll(x => x.Id == fittingHerbivores[0].Id);
                                fittingHerbivores.RemoveAll(x => x.Id == fittingHerbivores[0].Id);
                            }
                            else
                            {
                                WagonPrinter(wagon);
                                wagon = wagonMan.NewWagon();
                            }
                        }
                        else
                        {
                            WagonPrinter(wagon);
                            wagon = wagonMan.NewWagon();
                        }

                        // zo niet, doe een kleinere carnivoor in als dat kan
                    }
                }
                // nee geen ruimte, nieuwe wagon
                else
                {
                    WagonPrinter(wagon);
                    wagon = wagonMan.NewWagon();
                }
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
                    Console.WriteLine($"                                       |Carnivore|");
                }
                else
                {
                    Console.WriteLine($"                                       |Herbivore|");
                }

                // print de bijbehorende grootte
                if (animal.Size == 0)
                {
                    Console.WriteLine($"                                       |  Small  |");
                }
                else if (animal.Size == 1)
                {
                    Console.WriteLine($"                                       | Medium  |");
                }
                else
                {
                    Console.WriteLine($"                                       |  Large  |");
                }
                Console.WriteLine($"                                       |         |");
            }

            Console.WriteLine("                                       -----------");
            Console.WriteLine("                                            |     ");
        }

        public Animal FindBiggestCarnivore(List<Animal> animals)
        {
            List<Animal> carnivoresInList = new List<Animal>();
            carnivoresInList = animals.FindAll(x => x.IsCarnivore == true);
            if (carnivoresInList.Count != 0)
            {
                List<Animal> biggestCarnivoreFirst = new List<Animal>();
                biggestCarnivoreFirst = carnivoresInList.OrderByDescending(x => x.Size).ToList();
                Animal biggestCarnivoreInCarnivoreList = biggestCarnivoreFirst.First();

                return biggestCarnivoreInCarnivoreList;
            }
            return null;
        }
    }
}