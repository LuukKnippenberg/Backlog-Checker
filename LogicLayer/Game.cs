using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using Interfaces.Game;

namespace LogicLayer
{
    public class Game
    {
        IGamesDB gamesDB = new GamesDB();

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

        public void DeleteGame(string rights, int userId)
        {
            if (rights == "admin")
            {
                gamesDB.DeleteGame(Id);
            }
            else
            {
                gamesDB.DeleteGameUserLink(Id, userId);
            }

        }

        public void UpdateGame()
        {
            gamesDB.EditGame(CreateDTO());
        }

        public void ToggleUserGameRelation(string subject, int userId)
        {
            GamesDB gamesDB = new GamesDB();

            switch (subject)
            {
                case "owned":
                    Owned = !Owned;
                    gamesDB.ToggleUserGameRelation(Id, Owned, subject, userId);
                    break;
                case "completed":
                    Completed = !Completed;
                    gamesDB.ToggleUserGameRelation(Id, Completed, subject, userId);
                    break;
                case "interested":
                    Interested = !Interested;
                    gamesDB.ToggleUserGameRelation(Id, Interested, subject, userId);
                    break;

            }
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
