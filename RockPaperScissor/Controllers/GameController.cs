using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissor.Business.Services;
using RockPaperScissor.Domain.Enum;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<Game>>> GetAllGames()
    {
        return await _gameService.GetAllGames();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGameById([FromRoute]Guid id)
    {
        var game =  await _gameService.GetGameById(id);
        return Ok(game);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<Game>> CreateGame()
    {
        var game =  await _gameService.CreateGame();
        return Ok(game);
    }
    
    [HttpPost("finish/{id}")]
    public async Task<ActionResult<Game>> FinishGame([FromRoute]Guid id)
    {
        var game = await _gameService.FinishGame(id);
        return Ok(game);
    }
    
    [HttpPost("play/{id}")]
    public async Task<ActionResult<Game>> PlayGame([FromRoute]Guid id, [FromBody][Required]Move playerMove)
    {
        var game = await _gameService.PlayGame(id, playerMove);
        return Ok(game);
    }
}