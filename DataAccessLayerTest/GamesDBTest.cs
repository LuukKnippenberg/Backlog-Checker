using System;
using System.Collections.Generic;
using Interfaces.Game;
using ModelsDTO;

namespace DataAccessLayerTest
{
    public class GamesDBTest : IGamesDB, IGamesManagerDB
    {

        public bool DeleteGame(int gameId)
        {
            return true;
        }

        public bool DeleteGameUserLink(int gameId, int userId)
        {
            return true;
        }

        public bool EditGame(GamesModelDTO gamesModelDTO)
        {
            return true;
        }

        public bool AddGame(GamesModelDTO gamesModelDTO)
        {
            return true;
        }

        public List<GamesModelDTO> GetAllGames(int userId)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();
            GamesModelDTO tempGamesModel = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };
            int amount = 1;

            for (int i = 0; i < amount; i++)
            {
                tempGamesModel.Id = i;
                gamesModelList.Add(tempGamesModel);     
            }

            return gamesModelList;
        }

        public List<GamesModelDTO> GetGamesForUserById(int userId)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();
            if (userId == 0)
            {
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
            }

            return gamesModelList;
        }

        public List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();

            if (userId == 0)
            {
                GamesModelDTO tempGamesModel = new GamesModelDTO
                {
                    Id = 0,
                    Description = "This is the game",
                    Title = "Game title yeah",
                    HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
                };
                gamesModelList.Add(tempGamesModel);
            }

            return gamesModelList;

        }

        public GamesModelDTO GetSingleGame(int id)
        {
            List<GamesModelDTO> tempGamesModelList = new List<GamesModelDTO>();
            GamesModelDTO gamesModelToReturn = new GamesModelDTO();
            GamesModelDTO tempGamesModel = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };
            int amountOfGames = 10;

            for (int i = 0; i < amountOfGames; i++)
            {
                tempGamesModel.Id = i;
                tempGamesModelList.Add(tempGamesModel);
            }

            foreach (var item in tempGamesModelList)
            {
                if(id == item.Id)
                {
                    gamesModelToReturn = item;
                }
            }

            return gamesModelToReturn;
        }

        public GamesModelDTO GetSingleGameForUserById(int gameId, int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@UserId", userId.ToString() }
            };

            var query = "SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM games INNER JOIN users_games ON games.id = users_games.game_id AND users_games.user_id = @UserId AND games.id = @GameId";

            List<string> resultStringList = new List<string>
            {
                "1",
                "The title",
                "The description",
                "The URL"
            };

            return new GamesModelDTO
            {
                Id = Convert.ToInt32(resultStringList[0]),
                Title = resultStringList[1],
                Description = resultStringList[2],
                HeaderUrl = resultStringList[3]
            };
        }

        public GamesModelDTO GetSingleGame(int gameId, int userId)
        {
            List<GamesModelDTO> tempGamesModelList = new List<GamesModelDTO>();
            GamesModelDTO gamesModelToReturn = new GamesModelDTO();
            GamesModelDTO tempGamesModel = new GamesModelDTO
            {
                Description = "This is the game",
                Title = "Game title yeah",
                HeaderUrl = "https://pbs.twimg.com/media/ELNuLFMXYAA25hT?format=jpg&name=4096x4096"
            };
            int amountOfGames = 10;

            for (int i = 0; i < amountOfGames; i++)
            {
                tempGamesModel.Id = i;
                tempGamesModelList.Add(tempGamesModel);
            }

            foreach (var item in tempGamesModelList)
            {
                if (gameId == item.Id)
                {
                    gamesModelToReturn = item;
                }
            }

            return gamesModelToReturn;
        }

        public bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId)
        {
            return true;
        }
    }
}
