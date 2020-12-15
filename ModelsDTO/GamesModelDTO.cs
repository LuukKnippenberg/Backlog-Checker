using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDTO
{
    public class GamesModelDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HeaderUrl { get; set; }
        public bool Owned { get; set; }
        public bool Completed { get; set; }
        public bool interested { get; set; }
        public float HoursPlayed { get; set; }
        public List<string> Genres { get; set; }
    }
}
