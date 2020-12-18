using DataAccessLayer;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class GamesManager
    {
        private readonly GamesDB gamesDB = new GamesDB();
        private List<Game> games = new List<Game>();
        public GamesManager(int userId)
        {
            var AllGames = gamesDB.GetAllGames(userId);
            foreach (GamesModelDTO gamesModel in AllGames)
            {
                var game = new Game(gamesModel);
                games.Add(game);
            }
        }

        public List<Game> GetGamesForUserById(int userId)
        {
            games = ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserById(userId));
            return games;
        }

        public List<Game> GetGamesSortedAndOrFiltered(string sort, string filter, int userId)
        {
            List<Game> filteredList;

            if(filter == "all")
            {
                filteredList = ConvertModelDTOIntoGenericGameList(gamesDB.GetAllGames(userId));
            }
            else
            {
                filteredList = ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserByIdWithFilter(userId, filter, "1"));
            }

            games = filteredList;

            return games;
        }

        public GamesModelDTO GetSingleGame(int id)
        {
            return gamesDB.GetSingleGame(id);
        }

        public void AddGame(string title, string description, string headerUrl)
        {
            gamesDB.AddGame(title, description, headerUrl);
        }

        public void DeleteGame(int gameId, string rights, int userId) 
        {
            if(rights == "admin")
            {
                gamesDB.DeleteGame(gameId);
            }
            else
            {
                gamesDB.DeleteGameUserLink(gameId, userId);
            }
            
        }

        public void EditGame(int gameId)
        {
            gamesDB.EditGame(gameId);
        }

        public void ToggleUserGameRelation(int gameId, string subject, int userId)
        {
            foreach (var game in games)
            {
                if(game.Id == gameId)
                {
                    game.ToggleUserGameRelation(subject, userId);
                }
            }
        }

        private List<Game> ConvertModelDTOIntoGenericGameList(List<GamesModelDTO> gamesModelDTO)
        {
            List<Game> gamesTemp = new List<Game>();

            foreach (GamesModelDTO gamesModel in gamesModelDTO)
            {
                var game = new Game(gamesModel);
                gamesTemp.Add(game);
            }
            return gamesTemp;
        }
    }
}
