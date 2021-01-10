﻿using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Game
{
    public interface IGamesManagerDB
    {
        void AddGame(GamesModelDTO gamesModelDTO);
        List<GamesModelDTO> GetAllGames(int userId);
        List<GamesModelDTO> GetGamesForUserById(int userId);
        List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue);
        GamesModelDTO GetSingleGame(int id);
    }
}
