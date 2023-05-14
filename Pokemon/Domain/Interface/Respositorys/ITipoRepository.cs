using Domain.Models;
using Domain.Models.ViewModel;

namespace Domain.Interface.Respositorys;

public interface ITipoRepository
{
    Task<TipoId> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Tipos>> GetAllAsync(CancellationToken cancellationToken);
}