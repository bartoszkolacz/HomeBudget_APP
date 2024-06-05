﻿using HomeBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Interfaces
{
    public interface ITransactionCategoryRepository
    {
        Task Create(TransactionCategories transactionCategories);
    }
}
