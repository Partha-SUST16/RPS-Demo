namespace RockPaperScissor.Domain.Models;

public class GameStat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int RockCount { get; set; }
    public int PaperCount { get; set; }
    public int ScissorCount { get; set; }
    public int DrawMatchCount { get; set; }
    public int PlayerScore { get; set; }
    public int ComputerScore { get; set; }
}