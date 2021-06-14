using System;
using System.Collections.Generic;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Logic.Enum;

namespace Test.Unit
{
    [TestClass]
    public class AnimalControllerTest
    {
        [TestMethod]
        public void FindBiggestCarnivore_LargeCarnivore_ReturnsBiggestCarnivore()
        {
            // arrange
            Animal animal = new Animal();
            List<Animal> animals = new()
            {
                new Animal(0, true, 2, 5),
                new Animal(1, true, 1, 3),
                new Animal(3, false, 2, 5)
            };

            // act
            Animal biggestCarnivore = animal.FindBiggestCarnivore(animals);

            // assert
            Assert.AreEqual(0, biggestCarnivore.Id);
            Assert.AreEqual(true, biggestCarnivore.IsCarnivore);
            Assert.AreEqual(2, biggestCarnivore.Size);
            Assert.AreEqual(5, biggestCarnivore.Points);
        }

        [TestMethod]
        public void FindBiggestCarnivore_NoCarnivore_ReturnsNull()
        {
            // arrange
            Animal animal = new();
            List<Animal> animals = new()
            {
                new Animal(0, false, 2, 5),
                new Animal(1, false, 1, 3),
                new Animal(2, false, 0, 1)
            };

            // act
            Animal biggestCarnivore = animal.FindBiggestCarnivore(animals);

            // assert
            Assert.IsNull(biggestCarnivore);
        }

        
        [TestMethod]
        public void CanFitInWagon_SixPlusThree_ReturnsTrue()
        {
            // arrange
            Wagon wagon = new(0) {Points = 6};
            Animal animal = new(0, true, 1, 3);

            // act
            bool success = wagon.CanFitInWagon(animal);

            //assert
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void CanFitInWagon_SixPlusFive_ReturnsFalse()
        {
            // arrange
            Wagon wagon = new(0) {Points = 6};
            Animal animal = new(0, true, 2, 5);

            // act
            bool success = wagon.CanFitInWagon(animal);

            //assert
            Assert.IsFalse(success);
        }
    }
}