using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Domain.Entities
{
    public class Transaction
    {
        public int transactionId { get; set; }
        public string transactionName { get; set; } = default!;
        public string? transactionDescription { get; set; }
        public DateTime transactionCreatedAt { get; set; } = DateTime.UtcNow;
        public float transactionAmount { get; set; }
        public string? transactionCategory { get; set; }
        public string? CreatedById { get; set; }
        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = transactionName.ToLower().Replace(" ","-");
    }
}
