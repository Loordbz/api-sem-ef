using Domain.Models.ViewModel;

namespace Domain.Interface.Services;

public interface ITipoService
{
    Task<TipoId> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<TipoViewList>> GetAllAsync(CancellationToken cancellationToken);
}