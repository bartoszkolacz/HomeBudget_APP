using HomeBudget.Application.Services;
using HomeBudget.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HomeBudget.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService) 
        {
            _transactionService = transactionService;
        }  

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.Transaction transaction)
        {
            await _transactionService.Create(transaction);
            return RedirectToAction(nameof(Create)); //todo: refactor
        }
    }
}
