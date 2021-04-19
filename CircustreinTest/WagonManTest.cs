using System.Collections.Generic;
using System.Linq;
using Circustrein_Teun_Spithoven;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircustreinTest
{
    [TestClass]
    public class WagonManTest
    {
        [TestMethod]
        public void NewWagon_IsNotNull()
        {
            WagonMan wagonMan = new WagonMan();

            Wagon wagon = wagonMan.NewWagon();
            
            Assert.IsNotNull(wagon);
        }
        
        [TestMethod]
        public void DoesAnotherAnimalFit_SixPlusThree_ReturnsTrue()
        {
            // arrange
            WagonMan wagonMan = new WagonMan();
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
            WagonMan wagonMan = new WagonMan();
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
            WagonMan wagonMan = new WagonMan();
            Wagon wagon = new Wagon(0);
            List<Animal> animals = new List<Animal>();
            Animal animal = new Animal(0, true, 1, 3);
            animals.Add(animal);
            
            // act
            wagonMan.AddAnimalToWagon(animals.First(), animals, wagon);
            
            // assert
            Assert.AreEqual(animal, wagon.Animals.First());
        }
    }
}
