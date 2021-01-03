using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IGameDB
    {
        void ToggleUserGameRelation(string subject, int userId);

    }
}
