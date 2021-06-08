using System.Collections.Generic;
using System.Linq;
using Logic.Controllers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Unit
{
    [TestClass]
    public class WagonControllerTest
    {
        [TestMethod]
        public void NewWagon_IsNotNull()
        {
            WagonController wagonMan = new();

            Wagon wagon = wagonMan.NewWagon();

            Assert.IsNotNull(wagon);
        }

        [TestMethod]
        public void AddAnimalToWagon_MediumCarnivoreInEmptyWagon_AnimalAddedToWagon()
        {
            // arrange
            WagonController wagonMan = new();
            Wagon wagon = new(0);
            List<Animal> animals = new();
            Animal animal = new(0, true, 1, 3);
            animals.Add(animal);

            // act
            wagonMan.AddAnimalToWagon(animals.First(), animals, wagon);

            // assert
            Assert.AreEqual(animal, wagon.Animals.First());
        }
    }
}