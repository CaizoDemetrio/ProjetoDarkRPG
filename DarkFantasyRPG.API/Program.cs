using DarkFantasyRPG.Domain.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=game.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "DarkFantasyRPG API", 
        Version = "v1" 
    });
});

var app = builder.Build();

// Garante que o banco de dados e as tabelas sejam criados automaticamente ao iniciar
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    // Força a compatibilidade com a interface visual
    app.UseSwagger(options => 
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();