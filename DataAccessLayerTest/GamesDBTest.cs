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
            GamesModelDTO tempGamesModel = new GamesModelDTO();
            tempGamesModel.Completed = true;
            tempGamesModel.Description = "The Description All Games";
            tempGamesModel.Title = "The Title";
            tempGamesModel.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";
            int amount = 10;

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
            GamesModelDTO tempGamesModel = new GamesModelDTO();
            tempGamesModel.Completed = true;
            tempGamesModel.Description = "The Description For User By Id";
            tempGamesModel.Title = "The Title";
            tempGamesModel.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";
            int amount = 10;

            for (int i = 0; i < amount; i++)
            {
                tempGamesModel.Id = i;
                gamesModelList.Add(tempGamesModel);
            }

            return gamesModelList;
        }

        public List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue)
        {
            List<GamesModelDTO> gamesModelList = new List<GamesModelDTO>();
            GamesModelDTO tempGamesModel = new GamesModelDTO();
            tempGamesModel.Completed = true;
            tempGamesModel.Description = "The Description For User By Id With Filter";
            tempGamesModel.Title = "The Title";
            tempGamesModel.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";
            int amount = 10;

            for (int i = 0; i < amount; i++)
            {
                tempGamesModel.Id = i;
                gamesModelList.Add(tempGamesModel);
            }

            return gamesModelList;
        }

        public GamesModelDTO GetSingleGame(int id)
        {
            GamesModelDTO tempGamesModel = new GamesModelDTO();
            tempGamesModel.Id = 0;
            tempGamesModel.Completed = true;
            tempGamesModel.Description = "The Description For User By Id With Filter";
            tempGamesModel.Title = "The Title";
            tempGamesModel.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";

            return tempGamesModel;
        }

        public bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId)
        {
            return true;
        }
    }
}
