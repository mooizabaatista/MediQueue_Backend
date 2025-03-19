using MediQueue.Domain.Entities;
using MediQueue.Infra.Context;
using MediQueue.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediQueue.Infra.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly MediQueueContext _context;

    public PacienteRepository(MediQueueContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Paciente>> GetAllAsync()
    {
        return await _context.Pacientes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Paciente> GetByIdAsync(int id)
    {
        var paciente = await _context.Pacientes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (paciente == null)
            throw new InvalidOperationException("Paciente não encontrado.");

        return paciente;
    }

    public async Task<Paciente> CreateAsync(Paciente paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<Paciente> UpdateAsync(Paciente paciente)
    {
        var pacienteEncontrado = await GetByIdAsync(paciente.Id);
        if (pacienteEncontrado == null)
            throw new InvalidOperationException("Paciente não encontrado.");

        _context.Pacientes.Update(paciente);
        await _context.SaveChangesAsync();
        return paciente;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var paciente = await GetByIdAsync(id);
        if (paciente == null)
            throw new InvalidOperationException("Paciente não encontrado.");

        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
        return true;
    }
}
