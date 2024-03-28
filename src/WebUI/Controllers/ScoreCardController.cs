using GolfCaddie.Application.Common.Models;
using GolfCaddie.Application.ScoreCardCQRS.Commands.CreateScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Commands.DeleteScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Commands.UpdateScoreCard;
using GolfCaddie.Application.ScoreCardCQRS.Queries.GetScoreCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ScoreCardController : Controller
{
    private readonly IMediator _mediator;

    public ScoreCardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Get All ScoreCards
    [HttpGet]
    public async Task<IActionResult> ViewScoreCard()
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
        await _mediator.Send(command);
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

    public async Task<IActionResult> EditScoreCard(int id)
    {
        var query = new GetScoreCardByIdQuery { ScoreCardId = id };
        var scoreCard = await _mediator.Send(query);

        if (scoreCard == null)
        {
            return NotFound();
        }

        return View(scoreCard);
    }

    // Edit ScoreCard
    [HttpPost]
    public async Task<IActionResult> EditScoreCard(int id, UpdateScoreCardCommand command, ScoreCardDto scoreCardDto)
    {
        command.Id = id;
        await _mediator.Send(command);

        return RedirectToAction(nameof(ViewScoreCard));
    }
}

