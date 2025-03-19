using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Interfaces;
using MediQueue.Application.Validations;
using Microsoft.AspNetCore.Mvc;

namespace MediQueue.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    private readonly PacienteValidator _pacienteValidation;

    public PacientesController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
        _pacienteValidation = new PacienteValidator();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var pacientes = await _pacienteService.GetAllAsync();
            return Ok(pacientes);
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
            var paciente = await _pacienteService.GetByIdAsync(id);
            return Ok(paciente);
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

    [HttpPost]
    public async Task<IActionResult> Post(PacienteCommandDto paciente)
    {
        try
        {
            var validationResult = await _pacienteValidation.ValidateAsync(paciente);

            if (!validationResult.IsValid)
                return BadRequest(new { Errors = validationResult.Errors.Select(x => x.ErrorMessage) });

            var novoPaciente = await _pacienteService.CreateAsync(paciente);
            return CreatedAtAction(nameof(Get), new { id = novoPaciente.Id }, novoPaciente);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(PacienteCommandDto paciente)
    {
        try
        {
            var validationResult = await _pacienteValidation.ValidateAsync(paciente);

            if (!validationResult.IsValid)
                return BadRequest(new { Errors = validationResult.Errors.Select(x => x.ErrorMessage) });

            var pacienteAtualizado = await _pacienteService.UpdateAsync(paciente);
            return Ok(pacienteAtualizado);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var resultado = await _pacienteService.DeleteAsync(id);
            if (!resultado)
                return BadRequest("Erro ao deletar o paciente.");

            return NoContent();
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
