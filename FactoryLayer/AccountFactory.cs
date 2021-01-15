using Interfaces.Account;
using System;
using DataAccessLayer;
using DataAccessLayerTest;

namespace FactoryLayer
{
    public static class AccountFactory
    {
        public static IAccountsDB GetAccountsManagerDB(string source)
        {
            switch (source.ToLower())
            {
                case "release":
                    return new AccountsDB();
                case "test":
                    return new AccountsDBTest();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
