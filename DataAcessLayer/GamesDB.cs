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

            List<string[]> param = new List<string[]>()
            {
                new string[] {"@id", id.ToString() }
            };
            List<string> result = sqlConnection.ExecuteSearchQuery("SELECT * FROM games WHERE id = 1");
            //List<string[]> result = sqlConnection.ExecuteSearchQueryWithArrayReturn("SELECT * FROM games", param);
            //List<string[]> result = sqlConnection.ExecuteSearchQueryWithArrayReturn("SELECT * FROM games", param);
            /*
            foreach (string[] row in result)
            {
                GamesModel getGamesTemp = new GamesModel();
                getGamesTemp.id = Convert.ToInt32(row[0]);
                getGamesTemp.title = row[1].ToString();

                getGames.Add(getGamesTemp);
            }
            */

            return getGames;
        }

    }
}
