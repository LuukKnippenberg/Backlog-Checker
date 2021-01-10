using Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayerTest;

namespace LogicLayer
{
    public class Factory
    {
        public IGamesDB GetGamesDB(string source)
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

        public IGamesManagerDB GetGamesManagerDB(string source)
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
