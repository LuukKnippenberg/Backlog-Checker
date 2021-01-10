﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using ModelsDTO;

namespace LogicLayer
{
    public class AccountsManager
    {
        private readonly AccountsDB accountsDB = new AccountsDB();
        private Account currentlyLoggedInAccount;

        public void RegisterAccount(string username, string email, string password)
        {
            accountsDB.RegisterAccount(username, email, password);
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
