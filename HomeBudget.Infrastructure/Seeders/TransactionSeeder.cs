using HomeBudget.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Infrastructure.Seeders
{
    public class TransactionSeeder 
    {
        private readonly HomeBudgetDbContext _dbContext;
        public TransactionSeeder(HomeBudgetDbContext dbContext) 
        {
        _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Transactions.Any())
                {
                    var transaction1 = new Domain.Entities.Transaction()
                    {
                        transactionName = "Przelew1",
                        transactionDescription = "Pierwsza transakcja testowa",
                        transactionAmount = 142.21F,
                        transactionCategory = "Transport"
                    };
                    _dbContext.Transactions.Add(transaction1);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
