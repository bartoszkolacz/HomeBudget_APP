using HomeBudget.Application.Transaction.Commands.CreateTransaction;
using HomeBudget.Application.Transaction.Queries.GetAllTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;


namespace HomeBudget.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _mediator.Send(new GetAllTransactionsQuery());
            return View(transactions);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionCommand command)
        {
            if (!ModelState.IsValid) 
            {
                return View(command);

            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
