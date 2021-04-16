using Circustrein_Teun_Spithoven;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CircustreinTest
{
    [TestClass]
    public class AnimalManTest
    {
        [TestMethod]
        public void MakeAnimals_Count5_Succes()
        {
            // arrange
            AnimalMan animalMan = new AnimalMan();
            int count = 5;
            List<Animal> testAnimalList = new List<Animal>();

            // act
            testAnimalList = animalMan.MakeAnimals(count);

            // assert
            Assert.IsNotNull(testAnimalList[0]);
            Assert.IsNotNull(testAnimalList[1]);
            Assert.IsNotNull(testAnimalList[2]);
            Assert.IsNotNull(testAnimalList[3]);
            Assert.IsNotNull(testAnimalList[4]);
        }

        [TestMethod]
        public void MakeAnimals_CountZeroOrLower_ReturnsNull()
        {
            // arrange
            AnimalMan animalMan = new AnimalMan();
            int countZero = 0;
            int countNegative = -4;
            List<Animal> testAnimalListZero = new List<Animal>();
            List<Animal> testAnimalListNegative = new List<Animal>();

            // act
            testAnimalListZero = animalMan.MakeAnimals(countZero);
            testAnimalListNegative = animalMan.MakeAnimals(countNegative);

            // assert
            Assert.IsNull(testAnimalListZero);
            Assert.IsNull(testAnimalListNegative);
        }

        [TestMethod]
        public void FindBiggestCarnivore_LargeCarnivore_ReturnsBiggestCarnivore()
        {
            // arrange
            AnimalMan animalMan = new AnimalMan();
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
            AnimalMan animalMan = new AnimalMan();
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