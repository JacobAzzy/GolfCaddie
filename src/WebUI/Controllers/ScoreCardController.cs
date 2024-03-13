using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Commands.DeleteScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;
using GolfCaddie.Application.Common.Models;

namespace WebUI.Controllers;

public class ScoreCardController : Controller
{
    private readonly ILogger<ScoreCardController> _logger;
    private readonly IMediator _mediator;

    public ScoreCardController(ILogger<ScoreCardController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ViewScoreCardAsync()
    {
        var query = new GetAllScoreCardsQuery();
        var scoreCard = await _mediator.Send(query);

        if (scoreCard == null)
        {
            return NotFound();
        }

        return View(scoreCard);
    }

    // Navigate to Add ScoreCard
    public IActionResult AddScoreCard()
    {
        return View("AddScoreCard");
    }

    // Add ScoreCard
    [HttpPost]
    public async Task<IActionResult> AddScoreCard(CreateScoreCardCommand command, ScoreCardDto scoreCardDto)
    {
        var addedScoreCard = await _mediator.Send(command);
        return View("~/Views/ScoreCard/AddScoreCard.cshtml");
    }

    // Delete a ScoreCard
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScoreCard(int id)
    {
        var command = new DeleteScoreCardCommand(id);
        var result = await _mediator.Send(command);

        if (result)
        {
            return View("Home");
        }
        else
        {
            return NotFound(); // 404 Not Found
        }
    }

    // Edit ScoreCard
    [HttpPut("{id}")]
    public async Task<IActionResult> EditScoreCard(int id, UpdateScoreCardCommand command)
    {
        command.Id = id;
        var updatedScoreCard = await _mediator.Send(command);
        ViewData["Message"] = updatedScoreCard;
        return View("EditScoreCard");
    }

    // Get ScoreCard by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetScoreCard(int id)
    {
        var query = new GetScoreCardByIdQuery { ScoreCardId = id };
        var scoreCard = await _mediator.Send(query);

        if (scoreCard == null)
        {
            return NotFound();
        }

        return View("ViewScoreCards");
    }
}

