using Domain.Models.ViewModel;

namespace Domain.Interface.Respositorys
{
    public interface IPokemonRepository
    {
        Task<PokemonResponse> GetByIdAsync(int id, CancellationToken token);
        Task<IEnumerable<PokemonResponse>> GetByNameAsync(string nome, CancellationToken token);
        Task<IEnumerable<PokemonResponse>> GetAllAsync(CancellationToken token);
    }
}