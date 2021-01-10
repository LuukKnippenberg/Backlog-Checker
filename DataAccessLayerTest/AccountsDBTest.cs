using System;
using System.Collections.Generic;
using Interfaces.Account;
using ModelsDTO;

namespace DataAccessLayerTest
{
    public class AccountsDBTest : IAccountsDB
    {
        public AccountModelDTO GetAccountData(int id)
        {
            AccountModelDTO accountModelDTO = new AccountModelDTO();
            accountModelDTO.Id = 1;
            accountModelDTO.Username = "TestAccount";
            accountModelDTO.Password = "Totallyhashed";
            accountModelDTO.Rights = "admin";
            accountModelDTO.Name = "Testnaam";
            accountModelDTO.Surname = "Testachternaam";
            accountModelDTO.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";
            accountModelDTO.Email = "test@test.com";

            return accountModelDTO;
        }

        public AccountModelDTO LoginUser(string username, string password)
        {
            AccountModelDTO accountModelDTO = new AccountModelDTO();
            accountModelDTO.Id = 1;
            accountModelDTO.Username = "TestAccount";
            accountModelDTO.Password = "Totallyhashed";
            accountModelDTO.Rights = "admin";
            accountModelDTO.Name = "Testnaam";
            accountModelDTO.Surname = "Testachternaam";
            accountModelDTO.HeaderUrl = "https://support.steampowered.com/steamvr/Alyx/AlyxBanner.png";
            accountModelDTO.Email = "test@test.com";

            return accountModelDTO;
        }

        public bool RegisterAccount(string username, string email, string password)
        {
            return true;
        }
    }
}
