namespace Domain.Models.ViewModel;

public class PokemonRequest
{ 
    public string Nome { get; set; }
    public int Tipo { get; set; }
    public int Tipo2 { get; set; }
    public bool Evolucao { get; set; }
    public int EvolucaoId { get; set; }
}