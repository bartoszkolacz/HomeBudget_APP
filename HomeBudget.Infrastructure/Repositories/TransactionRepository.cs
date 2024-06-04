using HomeBudget.Domain.Entities;
using HomeBudget.Domain.Interfaces;
using HomeBudget.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Transaction>> GetAll()
         => await _dbContext.Transactions.ToListAsync();
        public Task<Domain.Entities.Transaction?> GetByName(string name)
        => _dbContext.Transactions.FirstOrDefaultAsync(cw => cw.transactionName.ToLower() == name.ToLower());
    }
}
