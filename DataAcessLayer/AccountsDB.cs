using DataAcessLayer;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AccountsDB
    {
        private SqlConnection sqlConnection = new SqlConnection();

        public void RegisterAccount(string username, string email, string password)
        {
            const string rights = "user";

            var query = $"INSERT INTO users(username, email, password, rights ) VALUES ('{username}', '{email}', '{password}', '{rights}')";

            sqlConnection.ExecuteSearchQuery(query);

            //string result = sqlConnection.ExecuteSearchQueryWithListReturn("SELECT * FROM games ORDER BY title");

        }

        public AccountModelDTO LoginUser(string username, string password)
        {
            var query = $"SELECT * from users WHERE username = '{username}' AND password = '{password}'";

            var result = sqlConnection.ExecuteSearchQuery(query);

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
