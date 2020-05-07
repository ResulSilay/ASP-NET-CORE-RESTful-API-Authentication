using TierApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TierApp.Core.Data.EF;
using TierApp.Data.Repository.EF;
using TierApp.Entity.Models;

namespace TierApp.Data.Repository.EF
{
    public class EfAuthRepository : EfEntityRepository<User, EFContext>, IAuthRepository { }
}
