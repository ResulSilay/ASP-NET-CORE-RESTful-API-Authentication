using System.Threading.Tasks;
using TierApp.Entity.Models;

namespace TierApp.Business.Abstract
{
    public interface IAuthService
    {
        User Register(User user);
        User Login(User user);
        Task<bool> Any(string email);
    }
}
