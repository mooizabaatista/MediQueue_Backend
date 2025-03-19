using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediQueue.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EspecialidadesController : ControllerBase
{
    private readonly IEspecialidadeService _EspecialidadeService;

    public EspecialidadesController(IEspecialidadeService EspecialidadeService)
    {
        _EspecialidadeService = EspecialidadeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var Especialidades = await _EspecialidadeService.GetAllAsync();
            return Ok(Especialidades);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var Especialidade = await _EspecialidadeService.GetByIdAsync(id);
            return Ok(Especialidade);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }   
}
