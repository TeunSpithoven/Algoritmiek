using System.Collections.Generic;
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
    }
}
