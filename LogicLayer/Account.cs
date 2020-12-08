using System;
using System.Collections.Generic;
using System.Text;
using ModelsDTO;

namespace LogicLayer
{
    class Account
    {
        public int Id { private set; get; }
        public string Username { private set; get; }
        public string Name { private set; get; }
        public string Surname { private set; get; }
        private string Password { set; get; }
        public string AvatarUrl { private set; get; }
        public string HeaderUrl { private set; get; }
        public string Rights { private set; get; }

        public Account(AccountModel accountModel)
        {
            Id = accountModel.Id;
            Username = accountModel.Username;
            Name = accountModel.Name;
            Surname = accountModel.Surname;
            AvatarUrl = accountModel.AvatarUrl;
            HeaderUrl = accountModel.HeaderUrl;
            Rights = accountModel.Rights;
            Password = accountModel.Password;
        }
    }
}
