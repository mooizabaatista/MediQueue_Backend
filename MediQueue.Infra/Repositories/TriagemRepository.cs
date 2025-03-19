using MediQueue.Domain.Entities;
using MediQueue.Infra.Context;
using MediQueue.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediQueue.Infra.Repositories;

public class TriagemRepository : ITriagemRepository
{
    private readonly MediQueueContext _context;

    public TriagemRepository(MediQueueContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Triagem>> GetAllAsync()
    {
        return await _context.Triagens
            .Include(x => x.Especialidade)
            .Include(x => x.Atendimento)
            .ThenInclude(x => x.Paciente)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Triagem> GetByIdAsync(int id)
    {
        var triagem = await _context.Triagens
            .Include(x => x.Especialidade)
            .Include(x => x.Atendimento)
            .ThenInclude(x => x.Paciente)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (triagem == null)
            throw new InvalidOperationException("Triagem não encontrada.");

        return triagem;
    }

    public async Task<Triagem> CreateAsync(Triagem triagem)
    {
        await _context.Triagens.AddAsync(triagem);
        await _context.SaveChangesAsync();
        return triagem;
    }

    public async Task<Triagem> UpdateAsync(Triagem triagem)
    {
        var triagemEncontrada = await GetByIdAsync(triagem.Id);
        if (triagemEncontrada == null)
            throw new InvalidOperationException("Triagem não encontrada.");

        _context.Triagens.Update(triagem);
        await _context.SaveChangesAsync();
        return triagem;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var triagem = await GetByIdAsync(id);
        if (triagem == null)
            throw new InvalidOperationException("Triagem não encontrada.");

        _context.Triagens.Remove(triagem);
        await _context.SaveChangesAsync();
        return true;
    }
}
