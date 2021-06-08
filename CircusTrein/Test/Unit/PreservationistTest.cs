using System;
using System.Collections.Generic;
using Logic.Controllers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Logic.Enum;

namespace Test.Unit
{
    [TestClass]
    public class PreservationistTest
    {
        [TestMethod]
        public void FindFittingAnimal_MediumCarnivoreInWagonLargeHerbivoreInList_ReturnsLargeHerbivore()
        {
            // arrange
            WagonController wagonMan = new();
            Wagon wagon = wagonMan.NewWagon();
            Animal mediumCarnivore = new(0, true, 1, 3);
            wagon.Animals.Add(mediumCarnivore);
            List<Animal> animals = new();
            Animal largeHerbivore = new(1, false, 2, 5);
            animals.Add(largeHerbivore);

            // act
            Animal foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);

            // assert
            Assert.AreEqual(largeHerbivore, foundAnimal);
        }

        [TestMethod]
        public void FindFittingAnimal_LargeCarnivoreInWagonMediumHerbivoreInList_ReturnsNull()
        {
            // arrange
            WagonController wagonMan = new();
            Wagon wagon = wagonMan.NewWagon();
            Animal largeCarnivore = new(0, true, Convert.ToInt32(Enum.Sizes.Large), 5);
            wagon.Animals.Add(largeCarnivore);
            List<Animal> animals = new();
            Animal mediumHerbivore = new(1, false, Convert.ToInt32(Enum.Sizes.Medium), 3);
            animals.Add(mediumHerbivore);

            // act
            Animal foundAnimal = Preservationist.FindFittingAnimal(animals, wagon);

            // assert
            Assert.IsNull(foundAnimal);
        }

        [TestMethod]
        public void DoesAnotherAnimalFit_SixPlusThree_ReturnsTrue()
        {
            // arrange
            WagonController wagonController = new();
            Wagon wagon = wagonController.NewWagon();
            wagon.Points = 6;
            Animal animal = new(0, true, 1, 3);

            // act
            bool success = AnimalController.CanFitInWagon(wagon, animal);

            //assert
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void DoesAnotherAnimalFit_SixPlusFive_ReturnsFalse()
        {
            // arrange
            WagonController wagonController = new();
            Wagon wagon = wagonController.NewWagon();
            wagon.Points = 6;
            Animal animal = new(0, true, 2, 5);

            // act
            bool success = AnimalController.CanFitInWagon(wagon, animal);

            //assert
            Assert.IsFalse(success);
        }
    }
}