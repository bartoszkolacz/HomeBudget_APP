using HomeBudget.Application.Transaction.Commands.CreateTransaction;
using HomeBudget.Application.Transaction.Queries.GetAllTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.Application.Transactions;
using HomeBudget.Domain.Interfaces;

using HomeBudget.Application.Transaction.Commands.EditTransaction;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using HomeBudget.Application.Transaction.Queries.GetTransactionByEncodedName;
using System.Data;
using HomeBudget.MVC.Models;
using Newtonsoft.Json;
using HomeBudget.MVC.Extensions;
using HomeBudget.Application.Transaction.Commands.DeleteTransaction;


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
        [Authorize(Roles = "Parent")]
        public async Task<IActionResult> Index()
        {
            var transactions = await _mediator.Send(new GetAllTransactionsQuery());
            return View(transactions);
        }



        [Authorize]
        [Route("Transaction/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetTransactionByEncodedNameQuery(encodedName));
            return View(dto);
        }






        //************************ CREATE **********************//
        [Authorize]
        public IActionResult Create()
        {
            return View();
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

            this.SetNotification("success", $"Dodano transakcje");

            return RedirectToAction(nameof(Index));
        }



        //************************ EDIT **********************//
        [Authorize]
        [Route("Transaction/{encodedName}/Edit")]

        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetTransactionByEncodedNameQuery(encodedName));
           
            if (!dto.IsEditable)    //jeśli użytkownik nie ma dostępu do dto, wyrzuca usera do NoAccess w Home
            {
                return RedirectToAction("NoAccess", "Home");
            }


            EditTransactionCommand model = _mapper.Map<EditTransactionCommand>(dto);
            
            return View(dto);
        }
        [HttpPost]
        [Authorize]
        [Route("Transaction/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditTransactionCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            this.SetNotification("info", $"Edytowano transakcje"); //notyfikacja o edycji transakcji
            return RedirectToAction(nameof(Index));
        }

        //************************ DELETE **********************//
        [Authorize(Roles = "Parent")]
        [Route("Transaction/{encodedName}/Delete")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            var dto = await _mediator.Send(new GetTransactionByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)    // if the user does not have access to dto, redirect to NoAccess in Home
            {
                return RedirectToAction("NoAccess", "Home");
            }

            DeleteTransactionCommand model = _mapper.Map<DeleteTransactionCommand>(dto);
            return View(model); // Show a confirmation view before deletion
        }

        [HttpPost]
        [Authorize]
        [Route("Transaction/{encodedName}/Delete")]
        public async Task<IActionResult> Delete(string encodedName, DeleteTransactionCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            this.SetNotification("info", "Transaction deleted successfully"); // Notification about transaction deletion
            return RedirectToAction(nameof(Index));
        }





    }
}
