using Dapper;
using Domain.Interface.Respositorys;
using Domain.Models.ViewModel;
using Infra.Data;

namespace Infra.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DbPokemon _dbContext;
    public PokemonRepository(DbPokemon dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<PokemonResponse>> GetAllAsync(CancellationToken token)
    {

        using (var con = _dbContext.Connection)
        {
            string query = "SELECT p.Nome, p.Pokedex, t.Tipo as [Tipo], ti.Tipo as [Tipo2], p.Evolucao, pok.Nome as [nomeEvolucao] FROM Pokemon p " +
                "LEFT JOIN Pokemon pok on pok.Id = p.EvolucaoId " +
                "LEFT JOIN PokemonTipo tp on tp.IdPokemon = p.id " +
                "LEFT JOIN Tipos t on t.Id = tp.IdTipo " +
                "LEFT JOIN Tipos ti on ti.Id = tp.IdTpo2;";

            return (await con.QueryAsync<PokemonResponse>(query)).ToList();
        }
    }

    public async Task<PokemonResponse> GetByIdAsync(int id, CancellationToken token)
    {
        using (var con = _dbContext.Connection)
        {
            string query = "SELECT p.Nome, p.Pokedex, t.Tipo as [Tipo], ti.Tipo as [Tipo2], p.Evolucao, pok.Nome as [nomeEvolucao] FROM Pokemon p " +
                "LEFT JOIN Pokemon pok on pok.Id = p.EvolucaoId " +
                "LEFT JOIN PokemonTipo tp on tp.IdPokemon = p.id " +
                "LEFT JOIN Tipos t on t.Id = tp.IdTipo " +
                $"LEFT JOIN Tipos ti on ti.Id = tp.IdTpo2 WHERE p.Id = " + id;

            return await con.QueryFirstAsync<PokemonResponse>
                (sql: query, param: id);
        }
    }

    public async Task<IEnumerable<PokemonResponse>> GetByNameAsync(string nome, CancellationToken token)
    {
        using (var con = _dbContext.Connection)
        {
            string query = "SELECT p.Nome, p.Pokedex, t.Tipo as [Tipo], ti.Tipo as [Tipo2], p.Evolucao, pok.Nome as [nomeEvolucao] FROM Pokemon p " +
                "LEFT JOIN Pokemon pok on pok.Id = p.EvolucaoId " +
                "LEFT JOIN PokemonTipo tp on tp.IdPokemon = p.id " +
                "LEFT JOIN Tipos t on t.Id = tp.IdTipo " +
                "LEFT JOIN Tipos ti on ti.Id = tp.IdTpo2 WHERE P.NOME LIKE '" + nome + "%'";

            return await con.QueryAsync<PokemonResponse>
                (sql: query, param: new { nome });
        }
    }
}