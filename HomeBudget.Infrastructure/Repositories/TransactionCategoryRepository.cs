using HomeBudget.Domain.Entities;
using HomeBudget.Infrastructure.Persistence;
using HomeBudget.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Infrastructure.Repositories
{
    public class TransactionCategoryRepository : ITransactionCategoryRepository
    {
        private readonly HomeBudgetDbContext _dbContext;
        public TransactionCategoryRepository(HomeBudgetDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        public async Task Create(TransactionCategories transactionCategories)
        {
           // _dbContext.Services.Add(transactionCategories);
           // await _dbContext.SaveChangesAsync();
        }
    }

    
}
