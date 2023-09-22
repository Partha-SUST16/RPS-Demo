using RockPaperScissor.Domain.Enum;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.Business.Services;

public class GameLogicService : IGameLogicService
{
    private static readonly Dictionary<Move, Move> WinningMoves = new()
    {
        { Move.Rock, Move.Paper },
        { Move.Paper, Move.Scissor },
        { Move.Scissor, Move.Rock },
    };

    public Game CalculateComputerMove(Move playerMove, Game game)
    {
        Move computerMove = GenerateComputerMove(game);
        if (playerMove == computerMove)
        {
            game.DrawMatchCount++;
            game.GameResult = "Tie";
        }
        else if (WinningMoves[computerMove] == playerMove)
        {
            game.PlayerScore++;
            game.GameResult = "Player wins";
        }
        else
        {
            game.ComputerScore++;
            game.GameResult = "Computer wins";
        }

        return game;
    }

    private Move GenerateComputerMove(Game game)
    {
        Dictionary<Move, int> moveCounts = new Dictionary<Move, int>
        {
            { Move.Rock, game.RockCount },
            { Move.Paper, game.PaperCount },
            { Move.Scissor, game.ScissorCount }
        };

        Move mostUsed = moveCounts.MaxBy(kv => kv.Value).Key;
        return WinningMoves[mostUsed];
    }
}