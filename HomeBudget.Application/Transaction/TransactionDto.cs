using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transactions
{
    public class TransactionDto
    {
        public string transactionName { get; set; } = default!;
        public string? transactionDescription { get; set; }
        public float transactionAmount { get; set; }
        public string? transactionCategory { get; set; }
        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
