using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Interfaces;
using MediQueue.Application.Validations;
using MediQueue.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediQueue.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TriagensController : ControllerBase
{
    private readonly ITriagemService _triagemService;
    private readonly TriagemValidator _triagemValidator;

    public TriagensController(ITriagemService triagemService)
    {
        _triagemService = triagemService;
        _triagemValidator = new TriagemValidator();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var triagens = await _triagemService.GetAllAsync();
            return Ok(triagens);
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
            var triagem = await _triagemService.GetByIdAsync(id);
            return Ok(triagem);
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
    public async Task<IActionResult> Post(TriagemCommandDto triagem)
    {
        try
        {
            var validationResult = await _triagemValidator.ValidateAsync(triagem);

            if (!validationResult.IsValid)
                return BadRequest(new { Errors = validationResult.Errors.Select(x => x.ErrorMessage) });

            var novaTriagem = await _triagemService.CreateAsync(triagem);
            return CreatedAtAction(nameof(Get), new { id = novaTriagem.Id }, novaTriagem);
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
    public async Task<IActionResult> Put(TriagemCommandDto triagem)
    {
        try
        {
            var validationResult = await _triagemValidator.ValidateAsync(triagem);

            if (!validationResult.IsValid)
                return BadRequest(new { Errors = validationResult.Errors.Select(x => x.ErrorMessage) });


            var triagemAtualizada = await _triagemService.UpdateAsync(triagem);
            return Ok(triagemAtualizada);
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
            var resultado = await _triagemService.DeleteAsync(id);
            if (!resultado)
                return BadRequest("Erro ao deletar a triagem.");

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
