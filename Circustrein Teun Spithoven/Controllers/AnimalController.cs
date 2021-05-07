﻿using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein_Teun_Spithoven.Models;

namespace Circustrein_Teun_Spithoven.Controllers
{
    public class AnimalController
    {
        public Animal TheAnimalThatFits;
        public WagonController wagonMan;

        public List<Animal> MakeRandomAnimals(int amount)
        {
            if (amount > 0)
            {
                List<Animal> returnList = new List<Animal>();

                for (int i = 0; i < amount; i++)
                {
                    Random random = new();

                    int randomIsCarnivore = random.Next(2);
                    bool isCarnivore = Convert.ToBoolean(randomIsCarnivore);

                    int randomSize = random.Next(3);

                    int points = randomSize switch
                    {
                        0 => 1,
                        1 => 3,
                        2 => 5,
                        _ => 0
                    };

                    Animal animal = new (i, isCarnivore, randomSize, points);
                    returnList.Add(animal);
                }

                return returnList;
            }

            return null;
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