using RockPaperScissor.Domain.Enum;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.Business.Services;

public interface IGameService
{
    Task<List<Game>> GetAllGames();
    Task<Game> GetGameById(Guid id);
    Task<Game> CreateGame();
    Task<Game> FinishGame(Guid id);
    Task<Game> PlayGame(Guid id, Move playerMove);
    Task<GameStat> GetGameStat();
}