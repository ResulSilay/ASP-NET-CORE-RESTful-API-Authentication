using TierApp.Business.Abstract;
using TierApp.Data.Abstract;
using TierApp.Entity.Models;
using TierApp.Core.Util.Hash;
using System.Threading.Tasks;

namespace TierApp.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User Register(User user)
        {
            user.Password = HashMD5.Create(user.Password);
            return _authRepository.Add(user);
        }

        public User Login(User user)
        {
            var _user = _authRepository.Get(x => x.Email == user.Email);

            if (_user == null)
                return null;

            if (HashMD5.Create(user.Password) != _user.Password)
                return null;

            return _user;
        }

        public async Task<bool> Any(string email)
        {
            if (await _authRepository.Any(x => x.Email == email))
                return true;

            return false;
        }
    }
}