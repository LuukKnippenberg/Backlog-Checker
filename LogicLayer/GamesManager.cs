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

        public List<GamesModel> GetGames(GamesModel gamesModel)
        {
            return gamesDB.GetAllGames();
        }

        public GamesModel GetSingleGame(int id)
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
    }
}
