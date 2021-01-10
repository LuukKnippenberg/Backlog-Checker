using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AccountsDB
    {
        private SqlConnection sqlConnection = new SqlConnection();

        public AccountModelDTO GetAccountData(int id)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Id", id.ToString() }

            };

            var query = $"SELECT * FROM users WHERE id = @Id";

            AccountModelDTO accountModel = ConvertQueryResultIntoAccountModelDTO(sqlConnection.ExecuteSearchQueryParameters(query, param));

            return accountModel;
        }

        public void RegisterAccount(string username, string email, string password)
        {


            const string rights = "user";

            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Username", username },
                new string[] { "@Email", email },
                new string[] { "@Password", password },
                new string[] { "@Rights", rights }

            };

            var query = $"INSERT INTO users(username, email, password, rights ) VALUES (@Username, @Email, @Password, @Rights)";

            sqlConnection.ExecuteSearchQueryParameters(query, param);

            //string result = sqlConnection.ExecuteSearchQueryWithListReturn("SELECT * FROM games ORDER BY title");

        }

        public AccountModelDTO LoginUser(string username, string password)
        {
            List<string[]> param = new List<string[]>()
            {
                new string[] { "@Username", username },
                new string[] { "@Password", password }

            };

            var query = $"SELECT * from users WHERE username = @Username AND password = @Password";

            var result = sqlConnection.ExecuteSearchQueryParameters(query, param);

            return ConvertQueryResultIntoAccountModelDTO(result);
        }

        private AccountModelDTO ConvertQueryResultIntoAccountModelDTO(List<string> queryResult)
        {
            AccountModelDTO model = new AccountModelDTO();

            if(queryResult.Count !=  0)
            {
                model.Id = Convert.ToInt32(queryResult[0]);
                model.Username = queryResult[1];
                model.Name = queryResult[2];
                model.Surname = queryResult[3];
                model.Email = queryResult[4];
                model.Password = queryResult[5];
                model.AvatarUrl = queryResult[6];
                model.HeaderUrl = queryResult[7];
                model.Rights = queryResult[8];
            }

            return model;
        }
    }
}
