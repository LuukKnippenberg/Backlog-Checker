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
        public List<GamesModelDTO> GetAllGames(int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserID", userId.ToString() }
            };

            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM games left JOIN users_games ON games.id = users_games.game_id AND users_games.user_id = @UserID";

            var result = sqlConnection.ExecuteSearchQueryWithListReturnParameters(query, param);

            return ConvertQueryResultsIntoRows(result);
        }

        public List<GamesModelDTO> GetGamesForUserById(int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserID", userId.ToString() }
            };

            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = @UserID";

            var gamesByUserId = sqlConnection.ExecuteSearchQueryWithListReturnParameters(query, param);

            return ConvertQueryResultsIntoRows(gamesByUserId);
        }

        public List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserID", userId.ToString() },
                new string[] { "@WhereClouse", whereClause},
                new string[] { "@WhereValue", whereValue}
            };
            var query = $"SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM users INNER JOIN users_games ON users_games.user_id = users.id INNER JOIN games ON users_games.game_id = games.id WHERE users_games.user_id = @UserId AND users_games.{whereClause} = @WhereValue";

            var gamesByUserId = sqlConnection.ExecuteSearchQueryWithListReturnParameters(query, param);

            return ConvertQueryResultsIntoRows(gamesByUserId);
        }

        public GamesModelDTO GetSingleGame(int id)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Id", id.ToString() }
            };

            GamesModelDTO gamesModel = new GamesModelDTO();

            var query = "select * FROM games WHERE id = @Id";

            List<string> resultStringList = sqlConnection.ExecuteSearchQueryParameters(query, param);

            gamesModel.Id = Convert.ToInt32(resultStringList[0]);
            gamesModel.Title = resultStringList[1];
            gamesModel.Description = resultStringList[2];
            gamesModel.HeaderUrl = resultStringList[3];

            return gamesModel;
        }

        public void ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId)
        {
            if (!IfRelationExistsBetweenGameAndUser(userId, gameId))
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

            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@UpdateWith", UpdateWithString },
                new string[] { "@FieldToUpdate", fieldToUpdate },
                new string[] { "@UserId", userId.ToString() }
            };

            var query = $"UPDATE users_games SET {fieldToUpdate} = b'{UpdateWithString}' WHERE user_id = @UserId AND game_id = @GameId";

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);
        }

        public void AddGame(string title, string description, string headerUrl)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Title", title},
                new string[] { "@Description", description},
                new string[] { "@HeaderUrl", headerUrl}
            };


            var query = $"INSERT INTO games(title, description, headerUrl ) VALUES (@Title, @Description, @HeaderUrl)";

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);

            return;
        }

        public void DeleteGame(int gameId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() }
            };

            var query = $"DELETE FROM games WHERE id = @GameId";

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);

            return;
        }

        public void DeleteGameUserLink(int gameId, int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@UserId", userId.ToString() }
            };

            var query = $"DELETE FROM users_games WHERE game_id = @GameId AND user_id = @UserId";

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);

            return;
        }

        public void EditGame(int gameId, string title, string description, string headerUrl) //NOT DONE GET GAMEID somehow
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@Title", title },
                new string[] { "@Description", description },
                new string[] { "@HeaderUrl", headerUrl },
            };

            var query = ($"UPDATE games SET title = @Title, description = @Description, headerUrl = @HeaderUrl WHERE id = @GameId");
            //var query = ($"SELECT * FROM games where id = {gameId}");

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);

            return;
        }

        private List<GamesModelDTO> ConvertQueryResultsIntoRows(List<List<string>> queryResult)
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
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserId", userId.ToString()},
                new string[] { "@GameId", gameId.ToString()},
            };

            var query = $"SELECT * FROM users_games WHERE user_id = @UserId AND game_id = @GameId";

            var result = sqlConnection.ExecuteSearchQueryParameters(query, param);

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
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserId", userId.ToString()},
                new string[] { "@GameId", gameId.ToString()},
            };

            var query = $"INSERT INTO users_games(game_id, user_id, interested, completed, owned) VALUES (@GameId, @UserId, '', '', '')";

            sqlConnection.ExecuteNonSearchQueryParameters(query, param);

            return;

        }

    }
}
