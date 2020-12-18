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
        public List<GamesModelDTO> GetAllGames(int userId)
        {
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM games left JOIN users_games ON games.id = users_games.game_id AND users_games.user_id = '{userId}'";

            var result = sqlConnection.ExecuteSearchQueryWithListReturn(query);

            return ConvertQueryResultsIntoRows(result);
        }

        public List<GamesModelDTO> GetGamesForUserById(int userID)
        {
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = '{userID}'";

            var gamesByUserId = sqlConnection.ExecuteSearchQueryWithListReturn(query);

            return ConvertQueryResultsIntoRows(gamesByUserId);
        }

        public List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue)
        {
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = '{userId}' AND users_games.{whereClause} = '{whereValue}'";

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

        public void ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId)
        {
            if(!IfRelationExistsBetweenGameAndUser(userId, gameId))
            {
                CreateRelationBetweenGameAndUser(userId, gameId);
            }

            string UpdateWithString = Convert.ToString(updateWith);
            if(UpdateWithString == "True" || UpdateWithString == "true")
            {
                UpdateWithString = "1";
            }
            else if(UpdateWithString == "False" || UpdateWithString == "false")
            {
                UpdateWithString = "0";
            }

            Console.WriteLine($"UPDATE users_games SET {fieldToUpdate} = b'{UpdateWithString}' WHERE user_id = '{userId}' AND game_id = '{gameId}'");

            var query = $"UPDATE users_games SET {fieldToUpdate} = b'{UpdateWithString}' WHERE user_id = '{userId}' AND game_id = '{gameId}'";

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
            var query = $"DELETE FROM games WHERE id = {gameId}";

            sqlConnection.ExecuteNonSearchQuery(query);

            return;
        }

        public void DeleteGameUserLink(int gameId, int userId)
        {
            var query = $"DELETE FROM users_games WHERE game_id = '{gameId}' AND user_id = '{userId}'";

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

                if(4 < row.Count)
                {
                    gamesModelTemp.Owned = ConvertStringBoolIntoNumericalBool(row[4]);
                }
                if(5 < row.Count)
                {
                    gamesModelTemp.Completed = ConvertStringBoolIntoNumericalBool(row[5]);
                }
                if(6 < row.Count)
                {
                    gamesModelTemp.interested = ConvertStringBoolIntoNumericalBool(row[6]);
                }

                gamesList.Add(gamesModelTemp);
            }

            return gamesList;
        }

        private bool ConvertStringBoolIntoNumericalBool(string boolString)
        {
            if(boolString == "" || boolString is null)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(Convert.ToInt32(boolString));
            }
            
        }

        private bool IfRelationExistsBetweenGameAndUser(int userId, int gameId)
        {
            var query = $"SELECT * FROM users_games WHERE user_id = '{userId}' AND game_id = '{gameId}'";

            var result = sqlConnection.ExecuteSearchQuery(query);

            if (result.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void CreateRelationBetweenGameAndUser(int userId, int gameId)
        {
            var query = $"INSERT INTO users_games(game_id, user_id, interested, completed, owned) VALUES ('{gameId}', '{userId}', '', '', '')";

            sqlConnection.ExecuteNonSearchQuery(query);

            return;

        }

    }
}
