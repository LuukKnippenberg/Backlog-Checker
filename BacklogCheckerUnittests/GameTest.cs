using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BacklogCheckerUnittests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException),
            "Expected amount of wagons does not equal the actual amount of wagons!")]
        public void DeleteGame_ExpectedIncorrectSyntax_False()
        {
            //Arrange
            string rights = "admin";
            //string 
            /*
            Train train = new Train();
            string name = "test";
            Animal.Diets diet = Animal.Diets.Herbivore;
            Animal.Sizes size = Animal.Sizes.Small;
            int expectedAmountOfWagons = 60;
            */

            //Act
            /*
            for (int i = 0; i < 35; i++)
            {
                train.AddAnimal(name, diet, size);
            }
            train.DistibuteAnimals();
            */

            //Assert
            /*
            int actual = train.wagonListReadOnly.Count;
            Assert.AreEqual(expectedAmountOfWagons, actual);
            */
        }
    }
}
