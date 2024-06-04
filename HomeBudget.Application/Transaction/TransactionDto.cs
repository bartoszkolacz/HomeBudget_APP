using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transactions
{
    public class TransactionCommand
    {
        [Required(ErrorMessage = "Tytuł transakcji jest wymagany")]
        public string transactionName { get; set; } = default!;
        [StringLength(20,MinimumLength = 2)]
        public string? transactionDescription { get; set; }
        [Required(ErrorMessage = "Kwota transakcji jest wymagana")]
        public float transactionAmount { get; set; }
        [Required(ErrorMessage = "Rodzaj transakcji jest wymagany")]
        public string? transactionCategory { get; set; }

    }
}
