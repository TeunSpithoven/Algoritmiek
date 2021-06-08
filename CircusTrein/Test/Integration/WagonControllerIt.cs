using System.Collections.Generic;
using System.Linq;
using Logic.Controllers;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Integration
{
    [TestClass]
    public class WagonControllerIt
    {
        [TestMethod]
        public void WagonFiller_BigCarnivoreAndMediumHerbivore_InSeparateWagons()
        {
            // arrange
            WagonController wagonController = new();
            List<Animal> animals = new();
            Animal bigCarnivore = new Animal(0, true, 2, 5);
            Animal mediumHerbivore = new Animal(1, false, 1, 3);
            animals.Add(bigCarnivore);
            animals.Add(mediumHerbivore);

            // act
            List<Wagon> wagons = wagonController.WagonFiller(animals);

            // assert
            Assert.AreEqual(bigCarnivore, wagons.First().Animals.First());
            Assert.AreEqual(mediumHerbivore, wagons.Last().Animals.First());
        }

        [TestMethod]
        public void WagonFiller_ElevenSmallHerbivores_OneFullWagonAndOneWithOne()
        {
            // arrange
            WagonController wagonController = new();
            Animal smallHerbivore = new(11, false, 0, 1);
            List<Animal> animals = new();
            for (int i = 1 ; i < 11 ; i++)
                animals.Add(new Animal(i, false, 0, 1));
            animals.Add(smallHerbivore);

            // act
            List<Wagon> wagons = wagonController.WagonFiller(animals);

            // assert
            Assert.AreEqual(10, wagons.First().Points);
            Assert.AreEqual(10, wagons.First().Animals.Count);
            Assert.AreSame(smallHerbivore, wagons.Last().Animals.First());
        }

        [TestMethod]
        public void WagonFiller_3()
        {

        }

        [TestMethod]
        public void WagonFiller_4()
        {

        }

        [TestMethod]
        public void WagonFiller_5()
        {

        }
    }
}
