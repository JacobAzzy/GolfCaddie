using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GolfCaddie.WebUI.Models;
using MediatR;

namespace WebUI.Controllers;

public class ScoreCardController : Controller
{
    private readonly ILogger<ScoreCardController> _logger;

    public ScoreCardController(ILogger<ScoreCardController> logger)
    {
        _logger = logger;
    }


    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;
    }

    // Add ScoreCard


    // Edit ScoreCard

    // Get ScoreCard

    // Filter ScoreCard (Score, date)
}

