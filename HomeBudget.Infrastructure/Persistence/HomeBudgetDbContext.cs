using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Infrastructure.Persistence
{
    public class HomeBudgetDbContext : IdentityDbContext
    {
        public HomeBudgetDbContext(DbContextOptions<HomeBudgetDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Transaction> Transactions { get; set; }
        public DbSet<Domain.Entities.TransactionCategories> Categories { get; set; }
        public object Services { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Transaction>()
                    .HasMany(c => c.Categories)             //relacja bazodanowa, -> ma wiele
                    .WithOne(s => s.Transaction)            //relacja bazodanowa, -> ma dokładnie jedno
                    .HasForeignKey(s => s.transactionId);   //relacja bazodanowa, -> definiowanie klucz obcy
        }
    }
}
