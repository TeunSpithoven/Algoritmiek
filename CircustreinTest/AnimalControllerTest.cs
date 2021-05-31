using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Circustrein.Controllers;
using Circustrein.Models;

namespace CircustreinTest
{
    [TestClass]
    public class AnimalControllerTest
    {
        [TestMethod]
        public void MakeRandomAnimals_Count5_Success()
        {
            // arrange
            AnimalController animalMan = new AnimalController();
            int count = 5;

            // act
            List<Animal> testAnimalList = animalMan.MakeRandomAnimals(count);

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
            AnimalController animalMan = new AnimalController();
            int countZero = 0;
            int countNegative = -4;
            List<Animal> testAnimalListZero = new();
            List<Animal> testAnimalListNegative = new();

            // act
            testAnimalListZero = animalMan.MakeRandomAnimals(countZero);
            testAnimalListNegative = animalMan.MakeRandomAnimals(countNegative);

            // assert
            Assert.IsNull(testAnimalListZero);
            Assert.IsNull(testAnimalListNegative);
        }

        [TestMethod]
        public void FindBiggestCarnivore_LargeCarnivore_ReturnsBiggestCarnivore()
        {
            // arrange
            AnimalController animalMan = new AnimalController();
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(0, true, 2, 5));
            animals.Add(new Animal(1, true, 1, 3));
            animals.Add(new Animal(3, false, 2, 5));

            // act
            Animal biggestCarnivore = animalMan.FindBiggestCarnivore(animals);

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
            AnimalController animalMan = new AnimalController();
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(0, false, 2, 5));
            animals.Add(new Animal(1, false, 1, 3));
            animals.Add(new Animal(2, false, 0, 1));

            // act
            Animal biggestCarnivore = animalMan.FindBiggestCarnivore(animals);

            // assert
            Assert.IsNull(biggestCarnivore);
        }
    }
}