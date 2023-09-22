using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RockPaperScissor.DbContext;
using RockPaperScissor.Domain.Enum;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.Business.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _gameDbContext;
    private readonly IGameLogicService _gameLogicService;

    public GameService(GameDbContext gameDbContext, IGameLogicService gameLogicService)
    {
        _gameDbContext = gameDbContext;
        _gameLogicService = gameLogicService;
    }

    public async Task<List<Game>> GetAllGames()
    {
        return await _gameDbContext.Games.ToListAsync();
    }

    public async Task<GameStat> GetGameStat()
    {
        var gameState = await _gameDbContext.GameStat.FirstOrDefaultAsync();
        
        if (gameState is not null) 
            return gameState;
        
        gameState = new GameStat();
        _gameDbContext.GameStat.Add(gameState);
        await _gameDbContext.SaveChangesAsync();

        return gameState;
    }

    public async Task<Game> GetGameById(Guid id)
    {
        Game? game = await _gameDbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
        
        if (game is null)
            throw new Exception($"Game not found for id: {id}");
        
        return game;
    }
    
    public async Task<Game> CreateGame()
    {
        Game game = new();
        _gameDbContext.Games.Add(game);
        await _gameDbContext.SaveChangesAsync();
        return game;
    }

    public async Task<Game> FinishGame(Guid id)
    {
        var game = await GetGameById(id);
        if (game is null)
            throw new Exception("Game not found");
        game.IsActive = false;
        await _gameDbContext.SaveChangesAsync();
        return game;
    }
    
    public async Task<Game> PlayGame(Guid id, Move playerMove)
    {
        var game = await GetGameById(id);
        var gameStat = await GetGameStat();
        if (!game.IsActive)
            throw new Exception("Game is finished");
        game.PlayerMove = playerMove;
        game = _gameLogicService.CalculateComputerMove(playerMove, game, gameStat);
        await _gameDbContext.SaveChangesAsync();
        return game;
    }
}