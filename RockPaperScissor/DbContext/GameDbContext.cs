using Microsoft.EntityFrameworkCore;
using RockPaperScissor.Domain.Models;

namespace RockPaperScissor.DbContext;

public class GameDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<Game> Games { get; set; }

    public GameDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("GameDb");
    }
}