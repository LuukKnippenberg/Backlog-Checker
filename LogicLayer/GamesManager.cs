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
        public GamesManager()
        {
            var AllGames = gamesDB.GetAllGames();
            foreach(GamesModelDTO gamesModel in AllGames)
            {
                var game = new Game(gamesModel);
                games.Add(game);
            }
        }

        public List<Game> GetGames()
        {
            //var result = gamesDB.GetAllGames();

            return games;
        }

        private List<Game> GetGamesUserData(List<Game> games, int userId)
        {
            List<Game> gamesWithUserData = new List<Game>();

            List<Game> queryResult = GetGamesForUserById(userId);

            foreach (var item in queryResult)
            {
                if (item.Owned == true)
                {
                    Console.Write(item.Id + " true");
                }
            }

            return games;
        }

        public List<Game> GetGamesForUserById(int id)
        {
            List<Game> gamesFromUser = ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserById(id));
            return gamesFromUser;
        }

        public List<Game> GetGamesSortedAndOrFiltered(string sort, string filter, int userId)
        {
            List<Game> filteredList = new List<Game>();

            if(filter == "owned")
            {
                foreach (var item in games)
                {
                    if (item.Owned)
                    {
                        filteredList.Add(item);
                    }
                }
            }

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

        public void DeleteGame(int gameId) 
        {
            gamesDB.DeleteGame(gameId);
        }

        public void EditGame(int gameId)
        {
            gamesDB.EditGame(gameId);
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
