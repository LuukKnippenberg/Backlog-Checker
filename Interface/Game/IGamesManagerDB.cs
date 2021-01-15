using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Game
{
    public interface IGamesManagerDB
    {
        List<GamesModelDTO> GetAllGames(int userId);
        List<GamesModelDTO> GetGamesForUserById(int userId);
        List<GamesModelDTO> GetGamesForUserByIdWithFilter(int userId, string whereClause, string whereValue);
        GamesModelDTO GetSingleGame(int gameId);
        GamesModelDTO GetSingleGameForUserById(int gameId, int userId);
        bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId);
        bool AddGame(GamesModelDTO gamesModelDTO);
        bool DeleteGame(int gameId);
        bool DeleteGameUserLink(int gameId, int userId);
        bool IfGameExists(int gameId);
        bool IfNameAlreadyExists(string title);
    }
}
