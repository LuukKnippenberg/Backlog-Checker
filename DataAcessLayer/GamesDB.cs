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

        //TODO SQL INJECTION
        public List<GamesModelDTO> GetAllGames()
        {
            var result = sqlConnection.ExecuteSearchQueryWithListReturn("SELECT * FROM games ORDER BY title");
            return ConvertQueryResultsIntoRows(result);
        }

        public List<GamesModelDTO> GetGamesForUserById(int id)
        {
            var gameIds = sqlConnection.ExecuteSearchQueryWithListReturn($"SELECT * FROM users_games where user_id = {id}");

            List<List<string>> result = new List<List<string>>(); 
            foreach(var item in gameIds)
            {
                int gameId = Convert.ToInt32(item[1]);
                result.Add(sqlConnection.ExecuteSearchQuery($"SELECT * from games WHERE id = {gameId}"));
            }
            return ConvertQueryResultsIntoRows(result);
        }

        public GamesModelDTO GetSingleGame(int id)
        {
            GamesModelDTO gamesModel = new GamesModelDTO();

            var query = "select * FROM games WHERE id = " + id;

            List<string> resultStringList = sqlConnection.ExecuteSearchQuery(query);

            gamesModel.Id = Convert.ToInt32(resultStringList[0]);
            gamesModel.Title = resultStringList[1];
            gamesModel.Description = resultStringList[2];
            gamesModel.HeaderUrl = resultStringList[3];

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

        public List<GamesModelDTO> ConvertQueryResultsIntoRows(List<List<string>> queryResult)
        {
            List<GamesModelDTO> gamesList = new List<GamesModelDTO>();

            foreach (List<string> row in queryResult)
            {
                GamesModelDTO gamesModelTemp = new GamesModelDTO();
                gamesModelTemp.Id = Convert.ToInt32(row[0]);
                gamesModelTemp.Title = row[1];
                gamesModelTemp.Description = row[2];
                gamesModelTemp.HeaderUrl = row[3];

                gamesList.Add(gamesModelTemp);
            }

            return gamesList;
        }

    }
}
