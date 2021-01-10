using ModelsDTO;

namespace Interfaces.Account
{
    public interface IAccountsDB
    {
        AccountModelDTO GetAccountData(int id);
        AccountModelDTO LoginUser(string username, string password);
        bool RegisterAccount(string username, string email, string password);
    }
}