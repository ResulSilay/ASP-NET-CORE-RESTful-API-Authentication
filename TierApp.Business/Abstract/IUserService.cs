using TierApp.Entity.Models;

namespace TierApp.Business.Abstract
{
    public interface IUserService
    {
        User GetUser(int userId);
        User Save(User user);
    }
}