using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backlog_Checker.Models.Games
{
    public class MyGamesViewModel
    {
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string HeaderUrl { get; set; }
    }
}
