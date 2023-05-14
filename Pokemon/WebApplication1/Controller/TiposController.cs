using Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/pokemon/")]
public class TiposController : ControllerBase
{
    private readonly ITipoService _service;
    public TiposController(ITipoService service) => _service = service;

    [HttpGet]
    [Route("tipos")]
    public async Task<IActionResult> GetAllTypes(CancellationToken token) =>
        Ok(await _service.GetAllAsync(token));


    [HttpGet]
    [Route("tipos/{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken token) =>
        Ok(await _service.GetByIdAsync(id, token));

}