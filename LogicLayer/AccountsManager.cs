using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class AccountsManager
    {
        private readonly AccountsDB accountsDB = new AccountsDB();

        public void RegisterAccount(string username, string email, string password)
        {
            accountsDB.RegisterAccount(username, email, password);
        }
    }
}
