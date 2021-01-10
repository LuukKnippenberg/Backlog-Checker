using ModelsDTO;
using System.Collections.Generic;

namespace Interfaces.Game
{
    public interface IGamesDB
    {
        void DeleteGame(int gameId);
        void DeleteGameUserLink(int gameId, int userId);
        void EditGame(GamesModelDTO gamesModelDTO);
        void ToggleUserGameRelation(int gameId, bool updateWith, string fieldToUpdate, int userId);
    }
}