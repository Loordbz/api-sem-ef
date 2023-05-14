using Domain.Exceptions;
using Domain.Interface.Respositorys;
using Domain.Interface.Services;
using Domain.Models;
using System.Net;

namespace Service.Service;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _repository;
    private readonly ITipoRepository _tipo;
    public PokemonService(IPokemonRepository repository, ITipoRepository tipo)
    {
        _repository = repository;
        _tipo = tipo;
    }

    public async Task<IEnumerable<Pokemon>> GetAllAsync(CancellationToken token)
    {
        var find = await _repository.GetAllAsync(token);
        if (find is null)
            CustomException.ThrowNewException(HttpStatusCode.NotFound, "Não há pokemons cadastrados");

        return find!.Select(x => new Pokemon
        {
            Nome = x.Nome!,
            Pokedex = x.Pokedex,
            Evolucao = x.Evolucao,
            Tipos = new Tipos()
            {
                Tipo = x.Tipo,
                Tipo2 = x.Tipo2
            },
            NomeEvolucao = x.NomeEvolucao
        });

    }

    public async Task<Pokemon> GetById(int id, CancellationToken token)
    {
        var find = await _repository.GetByIdAsync(id, token);
        if (find is null)
            CustomException.ThrowNewException(HttpStatusCode.NotFound, "Nenhum pokemon na pokedex");

        return new Pokemon
        {
            Nome = find.Nome,
            Pokedex = find.Pokedex,
            Evolucao = find.Evolucao,
            Tipos = new Tipos()
            {
                Tipo = find.Tipo,
                Tipo2 = find.Tipo2
            },
            NomeEvolucao = find.NomeEvolucao
        };
    }

    public async Task<IEnumerable<Pokemon>> GetByName(string nome, CancellationToken token)
    {
        var find = await _repository.GetByNameAsync(nome, token);
        if (find is null)
            CustomException.ThrowNewException(HttpStatusCode.NotFound, "Nenhum pokemon com esse nome");

        return find!.Select(x => new Pokemon
        {
            Nome = x.Nome!,
            Pokedex = x.Pokedex,
            Evolucao = x.Evolucao,
            Tipos = new Tipos()
            {
                Tipo = x.Tipo,
                Tipo2 = x.Tipo2
            },
            NomeEvolucao = x.NomeEvolucao
        });
    }
}