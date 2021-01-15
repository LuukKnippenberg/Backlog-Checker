using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Game;
using FactoryLayer;

namespace LogicLayer
{
    public class Game
    {
        IGamesDB gamesDB = GamesFactory.GetGamesDB("release");

        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public bool Owned { set; get; }
        public bool Completed { set; get; }
        public bool Interested { set; get; }
        public TimeSpan HoursPlayed { set; get; }
        public string HeaderUrl { set; get; }

        /*
        private List<string> Genres;
        public IReadOnlyCollection<List<string>> ReadonlyGenres
        {
            get { return (IReadOnlyCollection<List<string>>)Genres.AsReadOnly(); }
        }
        */

        public Game(GamesModelDTO gameDTO)
        {
            Id = gameDTO.Id;
            Title = gameDTO.Title;
            Description = gameDTO.Description;
            Owned = gameDTO.Owned;
            Completed = gameDTO.Completed;
            Interested = gameDTO.Interested;
            HoursPlayed = gameDTO.HoursPlayed;
            //Genres = gameDTO.Genres;
            HeaderUrl = gameDTO.HeaderUrl;
        }

        public Game()
        {

        }

        public Game(string datasource)
        {
            gamesDB = GamesFactory.GetGamesDB(datasource.ToLower());
        }

        public bool UpdateGame()
        {
            return gamesDB.EditGame(CreateDTO());
        }

        public bool  ToggleUserGameRelation(string subject, int userId)
        {
            switch (subject)
            {
                case "owned":
                    Owned = !Owned;
                    return gamesDB.ToggleUserGameRelation(Id, Owned, subject, userId);
                case "completed":
                    Completed = !Completed;
                    return gamesDB.ToggleUserGameRelation(Id, Completed, subject, userId); 
                case "interested":
                    Interested = !Interested;
                    return gamesDB.ToggleUserGameRelation(Id, Interested, subject, userId);
            }

            return false;
        }

        private GamesModelDTO CreateDTO()
        {
            GamesModelDTO gamesModelDTO = new GamesModelDTO()
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                Owned = this.Owned,
                Completed = this.Completed,
                Interested = this.Interested,
                HoursPlayed = this.HoursPlayed,
                //Genres = this.Genres,
                HeaderUrl = this.HeaderUrl,
            };
            return gamesModelDTO;
        }

    }
}
