using System;
using System.Collections.Generic;
using System.Text;
using ModelsDTO;

namespace LogicLayer
{
    public class Account
    {
        public int Id { private set; get; }
        public string Username { private set; get; }
        public string Name { private set; get; }
        public string Surname { private set; get; }
        private string Password { set; get; }
        public string AvatarUrl { private set; get; }
        public string HeaderUrl { private set; get; }
        public RightsTypes Rights { get; private set; }

        public enum RightsTypes
        {
            Admin = 0,
            User = 1
        }

        public Account(AccountModelDTO accountModel)
        {
            Id = accountModel.Id;
            Username = accountModel.Username;
            Name = accountModel.Name;
            Surname = accountModel.Surname;
            AvatarUrl = accountModel.AvatarUrl;
            HeaderUrl = accountModel.HeaderUrl;
            Rights = (RightsTypes)ConvertRightsStringIntoRightsTypes(accountModel.Rights);
            Password = accountModel.Password;
        }

        private int ConvertRightsStringIntoRightsTypes(string rights)
        {
            switch (rights)
            {
                case "admin":
                    return 0;
                case "user":
                    return 1;
                default:
                    return 1;
            }
        }

    }
}
