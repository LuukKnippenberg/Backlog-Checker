using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Backlog_Checker.Models.Home
{
    public class IndexViewModel
    {
        public string Name { get; set; }
        public string UserID { get; set; }

        public IndexViewModel(string username)
        {
            Name = "testnaampje";
        }

        
    }
}
