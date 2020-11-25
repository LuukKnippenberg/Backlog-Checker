using DataAcessLayer;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class GamesDB
    {
        private SqlConnection sqlConnection = new SqlConnection();

        public List<GamesModel> GetGames(int id)
        {
            List<GamesModel> getGames = new List<GamesModel>();

            List<List<string>> result = sqlConnection.ExecuteSearchQueryWithListReturn("SELECT * FROM games ORDER BY title");

            foreach( List<string> row in result)
            {
                GamesModel gamesModelTest = new GamesModel();
                gamesModelTest.id = Convert.ToInt32(row[0]);
                gamesModelTest.title = row[1];
                gamesModelTest.description = row[2];
                gamesModelTest.headerUrl = row[3];

                getGames.Add(gamesModelTest);
            }

            return getGames;
        }

    }
}
