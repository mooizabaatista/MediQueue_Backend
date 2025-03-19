using MediQueue.Domain.Entities;
using MediQueue.Infra.Context;
using MediQueue.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediQueue.Infra.Repositories;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly MediQueueContext _context;

    public EspecialidadeRepository(MediQueueContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Especialidade>> GetAllAsync()
    {
        return await _context.Especialidades
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Especialidade> GetByIdAsync(int id)
    {
        var especialidade = await _context.Especialidades
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (especialidade == null)
            throw new InvalidOperationException("Especialidade não encontrada.");

        return especialidade;
    }
}
