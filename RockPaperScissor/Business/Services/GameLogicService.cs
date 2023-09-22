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

    public Game CalculateComputerMove(Move playerMove, Game game, GameStat gameStat)
    {
        Move computerMove = GenerateComputerMove(gameStat);
        if (playerMove == computerMove)
        {
            gameStat.DrawMatchCount++;
            game.GameResult = "Tie";
        }
        else if (WinningMoves[computerMove] == playerMove)
        {
            gameStat.PlayerScore++;
            game.GameResult = "Player wins";
        }
        else
        {
            gameStat.ComputerScore++;
            game.GameResult = "Computer wins";
        }

        return game;
    }

    private Move GenerateComputerMove(GameStat gameStat)
    {
        Dictionary<Move, int> moveCounts = new Dictionary<Move, int>
        {
            { Move.Rock, gameStat.RockCount },
            { Move.Paper, gameStat.PaperCount },
            { Move.Scissor, gameStat.ScissorCount }
        };

        Move mostUsed = moveCounts.MaxBy(kv => kv.Value).Key;
        return WinningMoves[mostUsed];
    }
    
}