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
            return gamesDB.GetGames(gamesModel.id);
        }

        public List<GamesModel> GetSingleGame(int id)
        {
            return gamesDB.GetGames(id);
        }
    }
}
