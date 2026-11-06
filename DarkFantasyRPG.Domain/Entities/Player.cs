namespace DarkFantasyRPG.Domain.Entities;

public class Player
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "Desconhecido";

    // Status Core (Dark Fantasy)
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;
    public int Sanity { get; set; } = 100;
    public int MaxSanity { get; set; } = 100;
    public int Stealth { get; set; } = 10;

    // Estado da Jornada
    public string CurrentLocation { get; set; } = "Cela_Inicial";
    public List<Item> Inventory { get; set; } = new();

    // Regras de Negócio do Personagem
    public void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
    }

    public void DrainSanity(int amount)
    {
        Sanity = Math.Max(0, Sanity - amount);
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }
}