using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IGamesManagerDB
    {
        GamesModelDTO GetSingleGame(int gameId);
        void DeleteGame(int gameId, string rights, int userId);
        void EditGame(int gameId, string title, string description, string headerUrl);
        void ToggleUserGameRelation(int gameId, string subject, int userId);
    }
}
