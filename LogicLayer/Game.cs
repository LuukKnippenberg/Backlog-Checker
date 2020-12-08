using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Game
    {
        public int Id { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public bool Owned { private set; get; }
        public bool Completed { private set; get; }
        public float HoursPlayed { private set; get; }
        public string HeaderUrl { private set; get; }

        private List<string> Genres;
        public IReadOnlyCollection<List<string>> ReadonlyGenres
        {
            get { return (IReadOnlyCollection<List<string>>)Genres.AsReadOnly(); }
        }

        public Game(GamesModelDTO gameDTO)
        {
            Id = gameDTO.Id;
            Title = gameDTO.Title;
            Description = gameDTO.Description;
            Owned = gameDTO.Owned;
            Completed = gameDTO.Completed;
            HoursPlayed = gameDTO.HoursPlayed;
            Genres = gameDTO.Genres;
            HeaderUrl = gameDTO.HeaderUrl;
        }

    }
}
