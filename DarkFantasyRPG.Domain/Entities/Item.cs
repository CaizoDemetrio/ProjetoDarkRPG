namespace DarkFantasyRPG.Domain.Entities;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Arma", "Consumivel", "Ferramenta"
    public int ModifierValue { get; set; } // Dano, cura ou valor do bónus
}