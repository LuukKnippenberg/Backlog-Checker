using ModelsDTO;
using System.Collections.Generic;

namespace Interfaces.Game
{
    public interface IGamesDB
    {
        bool EditGame(GamesModelDTO gamesModelDTO);
        bool ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId);
    }
}