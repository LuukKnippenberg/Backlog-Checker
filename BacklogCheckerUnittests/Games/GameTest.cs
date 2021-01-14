using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using ModelsDTO;
using System.Collections.Generic;

namespace BacklogCheckerUnittests
{
    [TestClass]
    public class GameTest
    {
        /*
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException),
            "Expected amount of wagons does not equal the actual amount of wagons!")]
        */

        [TestMethod]
        public void GetGamesFiltered_FilterAllGames_AreNotEqual()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            List<Game> gamesList = new List<Game>();
            Game game = new Game
            {
                Id = 0,
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };
            gamesList.Add(game);

            string filter = "all";
            int userId = 1;

            //Act
            var result = gamesManager.GetGamesFiltered(filter, userId);

            //Assert
            Assert.AreNotEqual(result, gamesList);
        }
           
    }
}
