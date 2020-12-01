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

        public List<GamesModel> GetAllGames()
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

        public GamesModel GetSingleGame(int id)
        {
            GamesModel gamesModel = new GamesModel();

            var query = "select * FROM games WHERE id = " + id;

            List<string> resultStringList = sqlConnection.ExecuteSearchQuery(query);

            gamesModel.id = Convert.ToInt32(resultStringList[0]);
            gamesModel.title = resultStringList[1];
            gamesModel.description = resultStringList[2];
            gamesModel.headerUrl = resultStringList[3];

            //AddGame("test", "test", "linkiewinkie");

            return gamesModel;
        }

        public void AddGame(string title, string description, string headerUrl)
        {
            var query = $"INSERT INTO games(title, description, headerUrl ) VALUES ('{title}', '{description}', '{headerUrl}')";

            sqlConnection.ExecuteNonSearchQuery(query);

            return;
        }

        public void DeleteGame(int gameId)
        {
            var query = $"DELETE FROM games where id = {gameId}";

            sqlConnection.ExecuteNonSearchQuery(query);

            return;
        }

        public void EditGame(int gameId)
        {
            var query = ($"SELECT * FROM games where id = {gameId}");

            sqlConnection.ExecuteNonSearchQuery(query);

            return;
        }

    }
}
