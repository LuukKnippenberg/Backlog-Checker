using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using ModelsDTO;
using System.Collections.Generic;

namespace BacklogCheckerUnittests.Games
{
    [TestClass]
    public class GamesManagerTest
    {
        [TestMethod]
        public void GetGamesForUserById_ListEqualsExpectedList_True()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            int userId = 0;

            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();

            GamesModelDTO tempGamesModel = new GamesModelDTO
            {
                Completed = true,
                Description = "The Description For User By Id",
                Title = $"The Title",
                HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png"
            };
            int amount = 10;

            for (int i = 0; i < amount; i++)
            {
                tempGamesModel.Id = i;
                gamesModelList.Add(tempGamesModel);
            }

            //Act
            var result = gamesManager.GetGamesForUserById(userId);

            //Assert
            result.Equals(tempGamesModel);
        }

        [TestMethod]
        public void GetGamesForUserById_ListEqualsExpectedList_EqualsZero()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            int userId = 1;
            int expectedAmountOfGames = 0;

            //Act
            var result = gamesManager.GetGamesForUserById(userId);

            //Assert
            Assert.AreEqual(result.Count, expectedAmountOfGames);
        }

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

        [TestMethod]
        public void GetGamesFiltered_FilterAllGames_AreEqual()
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

            string filter = "completed";
            int userId = 0;

            //Act
            var result = gamesManager.GetGamesFiltered(filter, userId);

            //Assert
            Assert.AreEqual(result.Count, gamesList.Count);
            Assert.AreEqual(result[0].Id, gamesList[0].Id);
        }

        [TestMethod]
        public void GetSingleGame_GetSingleGameWithCorrectId_True()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            Game gameExpected = new Game
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };

            int gameId = 5;

            //Act
            Game result = gamesManager.GetSingleGame(gameId);

            //Assert
            Assert.AreEqual(gameExpected.Id, result.Id);
        }

        [TestMethod]
        public void GetSingleGame_GetSingleGameWithIncorrectId_True()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            Game gameExpected = new Game
            {
                Id = 12,
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };

            //Act
            Game result = gamesManager.GetSingleGame(gameExpected.Id);

            //Assert
            Assert.AreNotEqual(gameExpected.Id, result.Id);
        }

        [TestMethod]
        public void AddGame_ExpectAddSuccess_True()
        {
            //Arrange
            GamesManager gamesManager = new GamesManager("test");
            GamesModelDTO gameExpected = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };

            //Act
            bool result = gamesManager.AddGame(gameExpected);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToggleUserGameRelation_ChangeCompletedStatus_True() //Not Done
        {
            //Arrange
            int gameId = 1;
            string subject = "completed";
            int userId = 1;

            GamesManager gamesManager = new GamesManager("test");

            //Act
            bool result = gamesManager.ToggleUserGameRelation(gameId, subject, userId);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteGame_ChangeCompletedStatus_True() //Not done
        {
            //Arrange
            string rights = "admin";
            string subject = "completed";
            int userId = 1;

            GamesManager gamesManager = new GamesManager("test");
            GamesModelDTO gameExpected = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };

            //Act
            bool result = gamesManager.DeleteGame(rights, userId, userId);

            //Assert
            Assert.IsTrue(result);
        }

    }
}
