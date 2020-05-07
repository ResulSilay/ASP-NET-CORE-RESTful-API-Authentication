using TierApp.Core.Data;
using TierApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TierApp.Data.Abstract
{
    public interface IAuthRepository : IEntityRepository<User> { }
}