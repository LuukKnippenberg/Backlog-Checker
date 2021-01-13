﻿using ModelsDTO;
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
        public List<Game> GetGamesForUserById(int userId)
        {
            return ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserById(userId)); ;
        }

        public List<Game> GetGamesFiltered(string filter, int userId)
        {
            List<Game> filteredList;

            if(filter == "all")
            {
                filteredList = ConvertModelDTOIntoGenericGameList(gamesDB.GetAllGames(userId));
            }
            else
            {
                filteredList = ConvertModelDTOIntoGenericGameList(gamesDB.GetGamesForUserByIdWithFilter(userId, filter, "1"));
            }

            return filteredList;
        }

        public Game GetSingleGame(int gameId)
        {
            Game game = new Game(gamesDB.GetSingleGame(gameId));
            return game;
        }

        public void AddGame(GamesModelDTO gamesModelDTO)
        {
            gamesDB.AddGame(gamesModelDTO);
        }

        public void ToggleUserGameRelation(int gameId, string subject, int userId)
        {
           
            var AllGames = gamesDB.GetAllGames(userId);
            List<Game> games = new List<Game>();
            foreach (GamesModelDTO gamesModel in AllGames)
            {
                var game = new Game(gamesModel);
                games.Add(game);
            }
            
            foreach (var game in games)
            {
                if(game.Id == gameId)
                {
                    game.ToggleUserGameRelation(subject, userId);
                }
            }
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
    }
}
