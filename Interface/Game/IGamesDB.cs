using ModelsDTO;
using System.Collections.Generic;

namespace Interfaces.Game
{
    public interface IGamesDB
    {
        bool DeleteGame(int gameId);
        bool DeleteGameUserLink(int gameId, int userId);
        bool EditGame(GamesModelDTO gamesModelDTO);
        bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId);
    }
}