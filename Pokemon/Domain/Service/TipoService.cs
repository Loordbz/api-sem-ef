using Domain.Exceptions;
using Domain.Interface.Respositorys;
using Domain.Interface.Services;
using Domain.Models.ViewModel;
using System.Net;

namespace Service.Service;

public class TipoService : ITipoService
{
    private readonly ITipoRepository _repository;

    public TipoService(ITipoRepository repository) => _repository = repository;

    public async Task<IEnumerable<TipoViewList>> GetAllAsync(CancellationToken cancellationToken)
    {
        var find = await _repository.GetAllAsync(cancellationToken);
        if (find is null)
            CustomException.ThrowNewException(HttpStatusCode.NotFound, "Não há dados.");

        return find!.Select(x => new TipoViewList
        {
            Tipo = x.Tipo
        });
    }

    public async Task<TipoId> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var find = await _repository.GetByIdAsync(id, cancellationToken);
        if (find is null)
            CustomException.ThrowNewException(HttpStatusCode.NotFound, "Arquivo não encontrado");

        return new TipoId
        {
            Id = find!.Id,
            Tipo = find!.Tipo
        };
    }
}