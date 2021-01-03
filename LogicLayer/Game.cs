using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using Interfaces;

namespace LogicLayer
{
    public class Game : IGameDB
    {
        public int Id { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }
        public bool Owned { private set; get; }
        public bool Completed { private set; get; }
        public bool Interested { private set; get; }
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
            Interested = gameDTO.interested;
            HoursPlayed = gameDTO.HoursPlayed;
            Genres = gameDTO.Genres;
            HeaderUrl = gameDTO.HeaderUrl;
        }

        public void DeleteGame(GamesDB gamesDb)
        {
            gamesDb.DeleteGame(Id);
        }

        public void EditGame()
        {
            //TODO
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

    }
}
