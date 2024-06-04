using HomeBudget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Infrastructure.Persistence
{
    public class HomeBudgetDbContext : DbContext
    {
        public HomeBudgetDbContext(DbContextOptions<HomeBudgetDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Transaction> Transactions { get; set; }

    }
}
