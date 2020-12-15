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
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = '{1}'";

            var result = sqlConnection.ExecuteSearchQueryWithListReturn(query);

            return ConvertQueryResultsIntoRows(result);
        }

        public List<GamesModelDTO> GetGamesForUserById(int id)
        {
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = '{id}'";

            var gamesByUserId = sqlConnection.ExecuteSearchQueryWithListReturn(query);

            return ConvertQueryResultsIntoRows(gamesByUserId);
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

        public void ChangeUserToGameRelation(int gameId, string subject, int userId)
        {
            var query = $"SELECT * FROM users_games WHERE user";
        }

        public void ToggleBool(int gameId, bool updateWith, string fieldToUpdate)
        {
            string UpdateWithString = Convert.ToString(updateWith);
            if(UpdateWithString == "True")
            {
                UpdateWithString = "1";
            }
            else if(UpdateWithString == "False")
            {
                UpdateWithString = "0";
            }

            var query = $"UPDATE users_games SET {fieldToUpdate} = b'{UpdateWithString}' WHERE user_id = '1' AND game_id = '{gameId}'";

            sqlConnection.ExecuteNonSearchQuery(query);
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
                gamesModelTemp.Owned = ConvertStringBoolIntoNumericalBool(row[4]);
                gamesModelTemp.Completed = ConvertStringBoolIntoNumericalBool(row[5]);
                gamesModelTemp.interested = ConvertStringBoolIntoNumericalBool(row[6]);

                gamesList.Add(gamesModelTemp);
            }

            return gamesList;
        }

        private bool ConvertStringBoolIntoNumericalBool(string boolString)
        {
            return Convert.ToBoolean(Convert.ToInt32(boolString));
        }

    }
}
