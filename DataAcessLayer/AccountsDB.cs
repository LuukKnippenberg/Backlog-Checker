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
    }
}
