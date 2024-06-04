using FluentValidation;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Application.Transaction.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator(ITransactionRepository repository)
        {
            RuleFor(c => c.transactionName)
                .NotEmpty().WithMessage("Tytuł jest wymagany")
                .MinimumLength(2).WithMessage("Tytuł powinien mieć więcej niż 2 znaki")
                .MaximumLength(20).WithMessage("Maksymalna długość tytułu to 20 znaków")
                .Custom((value, context) =>                                             // SPRWADZANIE CZY ISTNIEJE 
                {                                                                       // TRANSAKCJA O TAKIEJ NAZWIE,
                    var existingTransaction = repository.GetByName(value).Result;
                    if (existingTransaction != null)
                    {
                        context.AddFailure($"Transakcja {value} już istnieje");         //
                    }                                                                   // TROCHĘ BEZ SENSU
                });                                                                     // NA TRANSAKCJĘ TO UŻYWAĆ

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
