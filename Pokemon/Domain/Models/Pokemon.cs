namespace Domain.Models;

public class Pokemon
{
    public string Nome { get; set; }
    public int Pokedex { get; set; }
    public bool Evolucao { get; set; }
    public Tipos? Tipos { get; set; }
    public string? NomeEvolucao { get; set; }
}