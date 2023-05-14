namespace Domain.Models.ViewModel;

public class PokemonResponse
{
    public string? Nome { get; set; }
    public int Pokedex { get; set; }
    public bool Evolucao { get; set; }
    public string Tipo { get; set; }
    public string Tipo2 { get; set; }
    public string? NomeEvolucao { get; set; }
}