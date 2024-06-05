using FluentValidation;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Commands.EditTransaction
{
    public class EditTransactionCommandValidator : AbstractValidator<EditTransactionCommand>
    {
        public EditTransactionCommandValidator(ITransactionRepository repository)
        {
            RuleFor(c => c.transactionDescription)
                .NotEmpty().WithMessage("Opis jest wymagany")
                .MaximumLength(100).WithMessage("Maksymalna długość opisu to 100 znaków");

            RuleFor(c => c.transactionAmount)
                .NotEmpty().WithMessage("Kwota jest wymagana");

            RuleFor(c => c.transactionCategory)
                .NotEmpty().WithMessage("Kategoria jest wymagana");
        }
    }
}
