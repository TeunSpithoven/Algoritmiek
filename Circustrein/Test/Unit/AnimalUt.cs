using System;
using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enum = Logic.Enum;

namespace Test.Unit
{
    [TestClass]
    public class AnimalUt
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
        public void FindBiggestHerbivore_BigHerbivore_ReturnsBigHerbivore()
        {
            // arrange
            Animal animal = new Animal();
            List<Animal> animals = new()
            {
                new Animal(0, false, 2, 5),
                new Animal(1, true, 1, 3),
                new Animal(3, true, 2, 5)
            };

            // act
            Animal biggestHerbivore = animal.FindBiggestHerbivore(animals);

            // assert
            Assert.AreEqual(0, biggestHerbivore.Id);
            Assert.AreEqual(false, biggestHerbivore.IsCarnivore);
            Assert.AreEqual(2, biggestHerbivore.Size);
            Assert.AreEqual(5, biggestHerbivore.Points);
        }

        [TestMethod]
        public void FindBiggestHerbivore_NoHerbivore_ReturnsNull()
        {
            // arrange
            Animal animal = new();
            List<Animal> animals = new()
            {
                new Animal(0, true, 2, 5),
                new Animal(1, true, 1, 3),
                new Animal(2, true, 0, 1)
            };

            // act
            Animal biggestHerbivore = animal.FindBiggestHerbivore(animals);

            // assert
            Assert.IsNull(biggestHerbivore);
        }
    }
}