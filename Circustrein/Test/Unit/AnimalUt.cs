using System;
using System.Collections.Generic;
using Logic.Controllers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Logic.Enum;

namespace Test.Unit
{
    [TestClass]
    public class AnimalControllerTest
    {
        [TestMethod]
        public void MakeRandomAnimals_Count5_Success()
        {
            // arrange
            int count = 5;

            // act
            List<Animal> testAnimalList = Animal.MakeRandomAnimals(count);

            // assert
            Assert.IsNotNull(testAnimalList[0]);
            Assert.IsNotNull(testAnimalList[1]);
            Assert.IsNotNull(testAnimalList[2]);
            Assert.IsNotNull(testAnimalList[3]);
            Assert.IsNotNull(testAnimalList[4]);
        }

        [TestMethod]
        public void MakeRandomAnimals_CountZeroOrLower_ReturnsNull()
        {
            // arrange
            int countZero = 0;
            int countNegative = -4;

            // act
            List<Animal> testAnimalListZero = Animal.MakeRandomAnimals(countZero);
            List<Animal> testAnimalListNegative = Animal.MakeRandomAnimals(countNegative);

            // assert
            Assert.IsNull(testAnimalListZero);
            Assert.IsNull(testAnimalListNegative);
        }

        [TestMethod]
        public void FindBiggestCarnivore_LargeCarnivore_ReturnsBiggestCarnivore()
        {
            // arrange
            List<Animal> animals = new()
            {
                new Animal(0, true, 2, 5),
                new Animal(1, true, 1, 3),
                new Animal(3, false, 2, 5)
            };

            // act
            Animal biggestCarnivore = Animal.FindBiggestCarnivore(animals);

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
            List<Animal> animals = new()
            {
                new Animal(0, false, 2, 5),
                new Animal(1, false, 1, 3),
                new Animal(2, false, 0, 1)
            };

            // act
            Animal biggestCarnivore = Animal.FindBiggestCarnivore(animals);

            // assert
            Assert.IsNull(biggestCarnivore);
        }

        
        [TestMethod]
        public void CanFitInWagon_SixPlusThree_ReturnsTrue()
        {
            // arrange
            Wagon wagon = new() {Points = 6};
            Animal animal = new(0, true, 1, 3);

            // act
            bool success = Animal.CanFitInWagon(wagon, animal);

            //assert
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void CanFitInWagon_SixPlusFive_ReturnsFalse()
        {
            // arrange
            Wagon wagon = new() {Points = 6};
            Animal animal = new(0, true, 2, 5);

            // act
            bool success = Animal.CanFitInWagon(wagon, animal);

            //assert
            Assert.IsFalse(success);
        }
    }
}