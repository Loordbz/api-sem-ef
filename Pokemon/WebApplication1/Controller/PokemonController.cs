using Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/pokemon/")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _service;
    public PokemonController(IPokemonService service) => _service = service;

    [HttpGet]
    [Route("lista")]
    public async Task<IActionResult> GetAll(CancellationToken token) =>
        Ok(await _service.GetAllAsync(token));

    [HttpGet]
    [Route("pokedex/{nome}")]
    public async Task<IActionResult> GetByName(string nome, CancellationToken token) =>
        Ok(await _service.GetByName(nome, token));

    [HttpGet]
    [Route("pokedex/{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken token) =>
        Ok(await _service.GetById(id, token));
}