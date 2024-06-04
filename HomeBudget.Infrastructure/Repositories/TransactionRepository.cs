using HomeBudget.Domain.Interfaces;
using HomeBudget.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly HomeBudgetDbContext _dbContext;
        public TransactionRepository(HomeBudgetDbContext dbContext) 
        {
            _dbContext = dbContext;
        }  
        public async Task Create(Domain.Entities.Transaction transaction)
        {
            _dbContext.Add(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
