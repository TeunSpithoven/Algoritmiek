using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein_Teun_Spithoven.Controllers;
using Circustrein_Teun_Spithoven.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Circustrein_Teun_Spithoven.Enum;

namespace CircustreinTest
{
    [TestClass]
    public class WagonControllerTest
    {
        [TestMethod]
        public void NewWagon_IsNotNull()
        {
            WagonController wagonMan = new WagonController();

            Wagon wagon = wagonMan.NewWagon();
            
            Assert.IsNotNull(wagon);
        }
        
        [TestMethod]
        public void DoesAnotherAnimalFit_SixPlusThree_ReturnsTrue()
        {
            // arrange
            WagonController wagonMan = new WagonController();
            int wagonPoints = 6;
            int animalPoints = 3;
            bool doesItFit;

            // act
            doesItFit = wagonMan.DoesAnotherAnimalFit(wagonPoints, animalPoints);

            //assert
            Assert.AreEqual(true, doesItFit);
            
        }

        [TestMethod]
        public void DoesAnotherAnimalFit_SixPlusFive_ReturnsFalse()
        {
            // arrange
            WagonController wagonMan = new WagonController();
            int wagonPoints = 6;
            int animalPoints = 5;
            bool doesItFit;

            // act
            doesItFit = wagonMan.DoesAnotherAnimalFit(wagonPoints, animalPoints);

            //assert
            Assert.AreEqual(false, doesItFit);
        }

        [TestMethod]
        public void AddAnimalToWagon_MediumCarnivoreInEmptyWagon_AnimalAddedToWagon()
        {
            // arrange
            WagonController wagonMan = new WagonController();
            Wagon wagon = new Wagon(0);
            List<Animal> animals = new List<Animal>();
            Animal animal = new Animal(0, true, 1, 3);
            animals.Add(animal);
            
            // act
            wagonMan.AddAnimalToWagon(animals.First(), animals, wagon);
            
            // assert
            Assert.AreEqual(animal, wagon.Animals.First());
        }

        [TestMethod]
        public void FindFittingAnimal_MediumCarnivoreInWagonLargeHerbivoreInList_ReturnsLargeHerbivore()
        {
            // arrange
            WagonController wagonMan = new();
            Wagon wagon = wagonMan.NewWagon();
            Animal mediumCarnivore = new Animal(0, true, 1, 3);
            wagon.Animals.Add(mediumCarnivore);
            List<Animal> animals = new List<Animal>();
            Animal largeHerbivore = new Animal(1, false, 2, 5);
            animals.Add(largeHerbivore);

            // act
            Animal foundAnimal = wagonMan.FindFittingAnimal(animals, wagon);

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
            List<Animal> animals = new List<Animal>();
            Animal mediumHerbivore = new Animal(1, false, Convert.ToInt32(Enum.Sizes.Medium), 3);
            animals.Add(mediumHerbivore);

            // act
            Animal foundAnimal = wagonMan.FindFittingAnimal(animals, wagon);

            // assert
            Assert.IsNull(foundAnimal);
        }
    }
}
