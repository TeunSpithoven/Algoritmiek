using System.Collections.Generic;
using Circustrein_Teun_Spithoven;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void WagonFiller_TwoLargeCarnivores_TwoWagonsCreated()
        {
            // arrange
            AnimalMan animalMan = new AnimalMan();
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(0, true, 2, 5));
            animals.Add(new Animal(0, true, 2, 5));

            // act
            // door deze code kan ik het niet testen dus ik moet het solid maken
            animalMan.WagonFiller(animals);

            // assert

        }
    }
}
