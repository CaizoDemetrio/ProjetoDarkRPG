using DarkFantasyRPG.Domain.Data;
using DarkFantasyRPG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarkFantasyRPG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly AppDbContext _context;

    public GameController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("iniciar")]
    public async Task<IActionResult> IniciarJogo([FromBody] IniciarJogoRequest request)
    {
        var player = new Player
        {
            Name = string.IsNullOrWhiteSpace(request.NomeJogador) ? "Desconhecido" : request.NomeJogador,
            CurrentLocation = "Cela_Inicial"
        };

        var barraDeFerro = new Item
        {
            Name = "Barra de Ferro Enferrujada",
            Type = "Arma",
            Description = "Um pedaço pesado e frio da grade da cela, arrancado pela abominação.",
            ModifierValue = 2
        };
        
        player.AddItem(barraDeFerro);

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return Ok(new 
        { 
            Mensagem = "O som de correntes enferrujadas ecoa. Você abre os olhos na escuridão da cela...",
            PlayerId = player.Id,
            Nome = player.Name,
            Localizacao = player.CurrentLocation
        });
    }

    [HttpGet("status/{id}")]
    public async Task<IActionResult> Status(Guid id)
    {
        var player = await _context.Players
            .Include(p => p.Inventory)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (player == null) 
            return NotFound("Personagem não encontrado nas cinzas da floresta.");

        return Ok(player);
    }
}

// Aqui está a classe adicionada no final do arquivo!
public class IniciarJogoRequest
{
    public string NomeJogador { get; set; } = string.Empty;
}