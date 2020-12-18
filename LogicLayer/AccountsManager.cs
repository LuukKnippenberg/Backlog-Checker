using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using ModelsDTO;

namespace LogicLayer
{
    public class AccountsManager
    {
        private readonly AccountsDB accountsDB = new AccountsDB();
        private Account CurrentlyLoggedInAccount;

        public void RegisterAccount(string username, string email, string password)
        {
            accountsDB.RegisterAccount(username, email, password);
        }

        public bool LoginAccount(string username, string password)
        {
            CurrentlyLoggedInAccount = new Account(accountsDB.LoginUser(username, password));

            if (CurrentlyLoggedInAccount.Id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GetAccountData(int userId)
        {

        }

        public Account ReturnLoggedInUserData()
        {
            return CurrentlyLoggedInAccount;
        }

        public void LogOutUser()
        {

        }
    }
}
