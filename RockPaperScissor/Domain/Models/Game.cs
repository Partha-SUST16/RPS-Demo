using RockPaperScissor.Domain.Enum;

namespace RockPaperScissor.Domain.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Move PlayerMove { get; set; }
    public Move ComputerMove { get; set; }
    public bool IsActive { get; set; } = true;
    public string? GameResult { get; set; }
}