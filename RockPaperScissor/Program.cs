using RockPaperScissor.Business.Services;
using RockPaperScissor.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameDbContext>();
builder.Services.AddScoped<IGameLogicService, GameLogicService>();
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();