using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Controllers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Logic.Enum;

namespace Test.Unit
{
    [TestClass]
    public class WagonUT
    {
        [TestMethod]
        public void AddAnimalToWagon_MediumCarnivoreInEmptyWagon_AnimalAddedToWagon()
        {
            // arrange
            List<Animal> animals = new();
            Animal animal = new(0, true, 1, 3);
            animals.Add(animal);

            // act
            var wagon = Wagon.AddAnimalToWagon(animals.First(), animals, new Wagon());

            // assert
            Assert.AreEqual(animal, wagon.Animals.First());
        }

        [TestMethod]
        public void FindFittingAnimal_MediumCarnivoreInWagonLargeHerbivoreInList_ReturnsLargeHerbivore()
        {
            // arrange
            Wagon wagon = new();
            Animal mediumCarnivore = new(0, true, 1, 3);
            wagon.Animals.Add(mediumCarnivore);
            List<Animal> animals = new();
            Animal largeHerbivore = new(1, false, 2, 5);
            animals.Add(largeHerbivore);

            // act
            Animal foundAnimal = Wagon.FindFittingAnimal(animals, wagon);

            // assert
            Assert.AreEqual(largeHerbivore, foundAnimal);
        }

        [TestMethod]
        public void FindFittingAnimal_LargeCarnivoreInWagonMediumHerbivoreInList_ReturnsNull()
        {
            // arrange
            Wagon wagon = new();
            Animal largeCarnivore = new(0, true, Convert.ToInt32(Logic.Enum.Sizes.Large), 5);
            wagon.Animals.Add(largeCarnivore);
            List<Animal> animals = new();
            Animal mediumHerbivore = new(1, false, Convert.ToInt32(Enum.Sizes.Medium), 3);
            animals.Add(mediumHerbivore);

            // act
            Animal foundAnimal = Wagon.FindFittingAnimal(animals, wagon);

            // assert
            Assert.IsNull(foundAnimal);
        }

        [TestMethod]
        public void FindFittingAnimal_OneSmallOneLargeHerbivoreInList_ReturnsLargeHerbivore()
        {
            // arrange
            Wagon wagon = new();
            List<Animal> animals = new();
            Animal largeHerbivore = new(0, false, Convert.ToInt32(Enum.Sizes.Large), 5);
            animals.Add(largeHerbivore);
            
            Animal smallHerbivore = new(1, false, Convert.ToInt32(Enum.Sizes.Small), 1);
            animals.Add(smallHerbivore);

            // act
            Animal foundAnimal = Wagon.FindFittingAnimal(animals, wagon);

            // assert
            // Assert.AreEqual(largeHerbivore.Id, foundAnimal.Id);
            Assert.AreEqual(largeHerbivore.IsCarnivore, foundAnimal.IsCarnivore);
            Assert.AreEqual(largeHerbivore.Size, foundAnimal.Size);
            Assert.AreEqual(largeHerbivore.Points, foundAnimal.Points);
        }
    }
}