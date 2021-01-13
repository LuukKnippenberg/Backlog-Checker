using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using ModelsDTO;
using Interfaces.Account;
using FactoryLayer;

namespace LogicLayer
{
    public class AccountsManager
    {
        IAccountsDB accountsDB = AccountFactory.GetAccountsManagerDB("release");
        //private readonly AccountsDB accountsDB = new AccountsDB();
        private Account currentlyLoggedInAccount;

        public bool RegisterAccount(string username, string email, string password)
        {
            return accountsDB.RegisterAccount(username, email, password);
        }

        public bool LoginAccount(string username, string password)
        {
            currentlyLoggedInAccount = new Account(accountsDB.LoginUser(username, password));

            if (currentlyLoggedInAccount.Id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public AccountModelDTO GetAccountData(int userId)
        {
            return accountsDB.GetAccountData(userId);
        }

        public Account ReturnLoggedInUserData()
        {
            return currentlyLoggedInAccount;
        }
    }
}
