using TierApp.Core.Data.EF;
using TierApp.Data.Abstract;
using TierApp.Data.Repository.EF;
using TierApp.Entity.Models;

namespace TierApp.Data.Repository.EF
{
    public class EfUserRepository : EfEntityRepository<User, EFContext>, IUserRepository { }
}
