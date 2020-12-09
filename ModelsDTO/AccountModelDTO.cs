using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDTO
{
    public class AccountModelDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string HeaderUrl { get; set; }
        public string Rights { get; set; }

    }
}
