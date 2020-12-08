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

        public List<Game> GetGamesSortedAndOrFiltered(string sort, string filter)
        {
            

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

        private List<Game> ConvertModelDTOIntoGenericGameList(GamesModelDTO gamesModelDTO)
        {

            return new List<Game>();
        }
    }
}
