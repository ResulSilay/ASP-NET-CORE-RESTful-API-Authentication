using TierApp.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace TierApp.Data.Repository.EF
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=TierApp; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}
