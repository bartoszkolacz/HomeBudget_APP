using HomeBudget.Application.Transaction.Commands.CreateTransaction;
using HomeBudget.Application.Transaction.Queries.GetAllTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;
using HomeBudget.Application.Transaction.Queries.GetTransactionByEncodedName;
using HomeBudget.Application.Transaction.Commands.EditTransaction;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace HomeBudget.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TransactionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _mediator.Send(new GetAllTransactionsQuery());
            return View(transactions);
        }



        [Authorize]
        public IActionResult Create()
        {
           return View();
        }

        [Route("Transaction/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetTransactionByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Transaction/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetTransactionByEncodedNameQuery(encodedName));
            EditTransactionCommand model = _mapper.Map<EditTransactionCommand>(dto);
            return View(dto);
        }






        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTransactionCommand command)
        {
            if (!ModelState.IsValid) 
            {
                return View(command);

            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Transaction/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditTransactionCommand command)
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
