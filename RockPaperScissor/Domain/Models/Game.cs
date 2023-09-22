namespace RockPaperScissor.Domain.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int RockCount { get; set; }
    public int PaperCount { get; set; }
    public int ScissorCount { get; set; }
    public bool IsActive { get; set; } = true;
    public string? GameResult { get; set; }
    public int DrawMatchCount { get; set; }
    public int PlayerScore { get; set; }
    public int ComputerScore { get; set; }
}