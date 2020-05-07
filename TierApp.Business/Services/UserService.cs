using System.Threading.Tasks;
using TierApp.Business.Abstract;
using TierApp.Data.Abstract;
using TierApp.Entity.Models;

namespace TierApp.Business.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(x => x.Id == userId);
        }

        public async Task<bool> AnyAsync(string email)
        {
            return await _userRepository.Any(x => x.Email == email);
        }

        public User Save(User user)
        {
            _userRepository.Update(user);
            return GetUser(user.Id);
        }
    }
}
