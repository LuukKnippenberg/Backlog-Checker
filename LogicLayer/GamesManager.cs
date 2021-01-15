using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Game;
using FactoryLayer;

namespace LogicLayer
{
    public class GamesManager
    {
        IGamesManagerDB gamesDB = GamesFactory.GetGamesManagerDB("release");

        public GamesManager()
        {

        }

        public GamesManager(string DatabaseSource)
        {
            gamesDB = GamesFactory.GetGamesManagerDB(DatabaseSource);
        }

        public List<Game> GetGamesForUserById(int userId)
        {
            return ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserById(userId)); ;
        }

        public List<Game> GetGamesFiltered(string filter, int userId)
        {
            if(filter == "all")
            {
                return ConvertModelDTOIntoGenericGameList(gamesDB.GetAllGames(userId));
            }
            else
            {
                return ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserByIdWithFilter(userId, filter, "1"));
            }
        }

        public Game GetSingleGame(int gameId)
        {
            Game game = new Game(gamesDB.GetSingleGame(gameId));
            return game;
        }

        public bool AddGame(GamesModelDTO gamesModelDTO)
        {
            if (gamesDB.AddGame(gamesModelDTO))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool ToggleUserGameRelation(int gameId, string subject, int userId)
        {
            Game game = new Game(gamesDB.GetSingleGameForUserById(gameId, userId));
            try
            {
                game.ToggleUserGameRelation(subject, userId);
                return true;
            }
            catch 
            {
                return false;
            }            
        }

        public bool DeleteGame(string rights, int userId, int gameId)
        {
            if (rights == "admin")
            {
                return gamesDB.DeleteGame(gameId);
            }
            else
            {
                return gamesDB.DeleteGameUserLink(gameId, userId);
            }

        }

        public bool IfGameExists(int gameId)
        {
            return gamesDB.IfGameExists(gameId);
        }

        public bool IfNameAlreadyExists(string title)
        {
            return gamesDB.IfNameAlreadyExists(title);
        }
        private List<Game> ConvertModelDTOIntoGenericGameList(List<GamesModelDTO> gamesModelDTO)
        {
            List<Game> gamesTemp = new List<Game>();

            foreach (GamesModelDTO gamesModel in gamesModelDTO)
            {
                var game = new Game(gamesModel);
                gamesTemp.Add(game);
            }
            return gamesTemp;
        }
    }
}
