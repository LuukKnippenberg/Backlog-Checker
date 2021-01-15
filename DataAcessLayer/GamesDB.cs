using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Game;

namespace DataAccessLayer
{
    public class GamesDB : IGamesDB, IGamesManagerDB
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

        public GamesModelDTO GetSingleGame(int gameId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Id", gameId.ToString() }
            };

            var query = "select * FROM games WHERE id = @Id";

            List<string> resultStringList = sqlConnection.ExecuteSearchQueryParameters(query, param);

            return new GamesModelDTO
            {
                Id = Convert.ToInt32(resultStringList[0]),
                Title = resultStringList[1],
                Description = resultStringList[2],
                HeaderUrl = resultStringList[3]
            };
        }

        public GamesModelDTO GetSingleGameForUserById(int gameId, int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@UserId", userId.ToString() }
            };

            var query = "SELECT games.*, users_games.owned, users_games.completed, users_games.interested FROM games INNER JOIN users_games ON games.id = users_games.game_id AND users_games.user_id = @UserId AND games.id = @GameId";

            List<string> resultStringList = sqlConnection.ExecuteSearchQueryParameters(query, param);

            return new GamesModelDTO
            {
                Id = Convert.ToInt32(resultStringList[0]),
                Title = resultStringList[1],
                Description = resultStringList[2],
                HeaderUrl = resultStringList[3],
                Owned = Convert.ToBoolean(resultStringList[4]),
                Completed = Convert.ToBoolean(resultStringList[5]),
                Interested = Convert.ToBoolean(resultStringList[6]),
            };
        }


        public bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId)
        {
            if (!IfRelationExistsBetweenGameAndUser(userId, gameId))
            {
                CreateRelationBetweenGameAndUser(userId, gameId);
            }

            List<string[]> param = new List<string[]>()
            {
                new string[] { "@FieldToUpdate", fieldToUpdate },
                new string[] { "@UpdateWith", Convert.ToInt32(updateWith).ToString() },
                new string[] { "@UserId", userId.ToString() },
                new string[] { "@GameId", gameId.ToString() }
            };

            var query = $"UPDATE users_games SET {fieldToUpdate} = @UpdateWith WHERE user_id = @UserId AND game_id = @GameId";

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);            
        }

        public bool AddGame(GamesModelDTO gamesModelDTO)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Title", gamesModelDTO.Title},
                new string[] { "@Description", gamesModelDTO.Description},
                new string[] { "@HeaderUrl", gamesModelDTO.HeaderUrl}
            };


            var query = $"INSERT INTO games(title, description, headerUrl ) VALUES (@Title, @Description, @HeaderUrl)";

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);  
        }

        public bool  DeleteGame(int gameId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() }
            };

            var query = $"DELETE FROM games WHERE id = @GameId";

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);
        }

        public bool DeleteGameUserLink(int gameId, int userId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString() },
                new string[] { "@UserId", userId.ToString() }
            };

            var query = $"DELETE FROM users_games WHERE game_id = @GameId AND user_id = @UserId";

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);
        }

        public bool EditGame(GamesModelDTO gamesModelDTO)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gamesModelDTO.Id.ToString() },
                new string[] { "@Title", gamesModelDTO.Title },
                new string[] { "@Description", gamesModelDTO.Description },
                new string[] { "@HeaderUrl", gamesModelDTO.HeaderUrl },
            };

            var query = ($"UPDATE games SET title = @Title, description = @Description, headerUrl = @HeaderUrl WHERE id = @GameId");

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);
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
                gamesModelTemp.Owned = row[4] == "" ? false : Convert.ToBoolean(row[4]);
                gamesModelTemp.Completed = row[5] == "" ? false : Convert.ToBoolean(row[5]);
                gamesModelTemp.Interested = row[6] == "" ? false : Convert.ToBoolean(row[6]);

                gamesList.Add(gamesModelTemp);
            }

            return gamesList;
        }

        private bool ConvertStringBoolIntoNumericalBool(string boolString)
        {
            if (boolString == "" || boolString is null)
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

        private bool CreateRelationBetweenGameAndUser(int userId, int gameId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@UserId", userId.ToString()},
                new string[] { "@GameId", gameId.ToString()},
            };

            var query = $"INSERT INTO users_games(game_id, user_id, interested, completed, owned) VALUES (@GameId, @UserId, '', '', '')";

            return sqlConnection.ExecuteNonSearchQueryParameters(query, param);
        }

        public bool IfGameExists(int gameId)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@GameId", gameId.ToString()}
            };

            var query = $"SELECT * FROM games WHERE id = @GameId";
            var result = sqlConnection.ExecuteSearchQueryParameters(query, param);

            if(result.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IfNameAlreadyExists(GamesModelDTO gamesModelDTO)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Title", gamesModelDTO.Title.ToString()}
            };

            var query = $"SELECT title FROM games WHERE title = @Title";
            var result = sqlConnection.ExecuteSearchQueryParameters(query, param);

            if (result.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
