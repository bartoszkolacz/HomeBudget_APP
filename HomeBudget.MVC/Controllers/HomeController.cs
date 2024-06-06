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
using System.Diagnostics;

namespace HomeBudget.MVC.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeController(/*ILogger<HomeController> logger,*/ IMediator mediator, IMapper mapper)
    {
        //_logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var transactions = await _mediator.Send(new GetAllTransactionsQuery());
        return View(transactions);
    }

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Budget()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Reports()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Family()
    {
        return View();
    }
    
    public IActionResult Transactions()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
