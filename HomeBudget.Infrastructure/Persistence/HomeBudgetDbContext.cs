using HomeBudget.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Infrastructure.Persistence
{
    public class HomeBudgetDbContext : IdentityDbContext
    {
        public HomeBudgetDbContext(DbContextOptions<HomeBudgetDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
