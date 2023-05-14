using Domain.Models;

namespace Domain.Interface.Services;

public interface IPokemonService
{
    Task<Pokemon> GetById(int id, CancellationToken token);
    Task<IEnumerable<Pokemon>> GetByName(string nome, CancellationToken token);
    Task<IEnumerable<Pokemon>> GetAllAsync(CancellationToken token);
}