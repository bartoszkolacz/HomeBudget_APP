using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Entities
{
    public class TransactionCategories
    {
        public int Id { get; set; }
        public string categoryName { get; set; } = default!;

        public int transactionId { get; set; } = default!;
        public Transaction Transaction { get; set; } = default!;

    }
}
