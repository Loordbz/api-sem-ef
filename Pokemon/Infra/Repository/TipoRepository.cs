using Dapper;
using Domain.Interface.Respositorys;
using Domain.Models;
using Domain.Models.ViewModel;
using Infra.Data;

namespace Infra.Repository;

public class TipoRepository : ITipoRepository
{
    private readonly DbPokemon _dbContext;
    public TipoRepository(DbPokemon dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Tipos>> GetAllAsync(CancellationToken token)
    {
        using (var con = _dbContext.Connection)
        {
            string query = "SELECT Id, Tipo FROM [dbo].[Tipos]";
            return (await con.QueryAsync<Tipos>(query)).ToList();
        }
    }

    public async Task<TipoId> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        using (var con = _dbContext.Connection)
        {
            string query = $"SELECT * FROM [dbo].[Tipos] WHERE Id = {id}";
            return await con.QueryFirstAsync<TipoId>
                (sql: query, param: new { id });
        }
    }
}