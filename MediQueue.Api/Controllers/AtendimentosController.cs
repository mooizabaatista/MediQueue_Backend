using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediQueue.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AtendimentosController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;

    public AtendimentosController(IAtendimentoService atendimentoService)
    {
        _atendimentoService = atendimentoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var atendimentos = await _atendimentoService.GetAllAsync();
            return Ok(atendimentos);
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
            var atendimento = await _atendimentoService.GetByIdAsync(id);
            return Ok(atendimento);
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
    public async Task<IActionResult> Post(AtendimentoCommandDto atendimento)
    {
        try
        {
            var novoAtendimento = await _atendimentoService.CreateAsync(atendimento);
            return CreatedAtAction(nameof(Get), new { id = novoAtendimento.Id }, novoAtendimento);
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
    public async Task<IActionResult> Put(AtendimentoCommandDto atendimento)
    {
        try
        {
            var atendimentoAtualizado = await _atendimentoService.UpdateAsync(atendimento);
            return Ok(atendimentoAtualizado);
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
            var resultado = await _atendimentoService.DeleteAsync(id);
            if (!resultado)
                return BadRequest("Erro ao deletar o atendimento.");

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

    [HttpGet("fila")]
    public async Task<IActionResult> GetFila()
    {
        try
        {
            var fila = await _atendimentoService.GetFilaAsync();
            return Ok(fila);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("chamar-proximo")]
    public async Task<IActionResult> ChamarProximo()
    {
        try
        {
            var proximoAtendimento = await _atendimentoService.ChamarProximoAsync();
            return Ok(proximoAtendimento);
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
