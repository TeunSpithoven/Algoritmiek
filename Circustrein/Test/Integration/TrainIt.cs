using System.Collections.Generic;
using System.Linq;
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
            List<Animal> animals = new();
            Train train = new();
            Animal bigCarnivore = new Animal(0, true, 2, 5);
            Animal mediumHerbivore = new Animal(1, false, 1, 3);
            animals.Add(bigCarnivore);
            animals.Add(mediumHerbivore);

            // act
            List<Wagon> wagons = train.WagonFiller(animals);

            // assert
            Assert.AreEqual(bigCarnivore, wagons.First().Animals.First());
            Assert.AreEqual(mediumHerbivore, wagons.Last().Animals.First());
        }

        [TestMethod]
        public void WagonFiller_ElevenSmallHerbivores_OneFullWagonAndOneWithOne()
        {
            // arrange
            Train train = new();
            Animal smallHerbivore = new(11, false, 0, 1);
            List<Animal> animals = new();
            for (int i = 1 ; i < 11 ; i++)
                animals.Add(new Animal(i, false, 0, 1));
            animals.Add(smallHerbivore);

            // act
            List<Wagon> wagons = train.WagonFiller(animals);

            // assert
            Assert.AreEqual(10, wagons.First().Points);
            Assert.AreEqual(10, wagons.First().Animals.Count);
            Assert.AreEqual(smallHerbivore.Id, wagons.First().Animals.First().Id);
        }

        [TestMethod]
        public void WagonFiller_TwoLargeCarnivoresOneLargeHerbivore_AllInSeparateWagons()
        {
            Train train = new();
            List<Animal> animals = new();
            animals.Add(new Animal(0, true, 2, 5));
            animals.Add(new Animal(1, true, 2, 5));
            animals.Add(new Animal(2, false, 2, 5));

            List<Wagon> wagons = train.WagonFiller(animals);

            Assert.AreEqual(3, wagons.Count);
            Assert.AreEqual(0, wagons[0].Animals[0].Id);
            Assert.AreEqual(1, wagons[1].Animals[0].Id);
            Assert.AreEqual(2, wagons[2].Animals[0].Id);
        }

        [TestMethod]
        public void WagonFiller_OneSmallCarnivoreThreeMediumHerbivores_AllInOneFullWagon()
        {
            Train train = new();
            List<Animal> animals = new();
            animals.Add(new Animal(0, true, 0, 1));
            animals.Add(new Animal(1, false, 1, 3));
            animals.Add(new Animal(2, false, 1, 3));
            animals.Add(new Animal(3, false, 1, 3));

            List<Wagon> wagons = train.WagonFiller(animals);

            Assert.AreEqual(1, wagons.Count);
            Assert.AreEqual(10, wagons[0].Points);
        }

        [TestMethod]
        public void WagonFiller_TwoMediumCarnivoresTwoLargeHerbivoresOneSmallHerbivore_ThreeWagonsCreatedSmallHerbivoreAloneInWagon()
        {
            Train train = new();
            List<Animal> animals = new();
            animals.Add(new Animal(0, true, 1, 3));
            animals.Add(new Animal(1, false, 2, 5));
            animals.Add(new Animal(2, true, 1, 3));
            animals.Add(new Animal(3, false, 2, 5));
            animals.Add(new Animal(4, false, 0, 1));

            List<Wagon> wagons = train.WagonFiller(animals);

            Assert.AreEqual(3, wagons.Count);
            Assert.AreEqual(0, wagons[0].Animals[0].Id);
            Assert.AreEqual(1, wagons[0].Animals[1].Id);
            Assert.AreEqual(2, wagons[1].Animals[0].Id);
            Assert.AreEqual(3, wagons[1].Animals[1].Id);
            Assert.AreEqual(4, wagons[2].Animals[0].Id);
        }
    }
}
