using RockPaperScissor.Domain.Enum;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.Business.Services;

public interface IGameLogicService
{
    Game CalculateComputerMove(Move playerMove, Game game);
}