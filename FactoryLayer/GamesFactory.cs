using Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayerTest;

namespace FactoryLayer
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
                    return new GamesDB();
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
                    return new GamesDB();
            }
        }
    }
}
