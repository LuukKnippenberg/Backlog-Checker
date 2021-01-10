using Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayerTest;

namespace LogicLayer
{
    public static class GamesFactory
    {
        public static IGamesDB GetGamesDB(string source)
        {
            switch (source.ToLower())
            {
                case "release":
                    return new GamesDB();
                case "test":
                    return new GamesDBTest();
                default:
                    throw new NotImplementedException();
            }
        }

        public static IGamesManagerDB GetGamesManagerDB(string source)
        {
            switch (source.ToLower())
            {
                case "release":
                    return new GamesDB();
                case "test":
                    return new GamesDBTest();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
