using MediQueue.Domain.Entities;
using MediQueue.Infra.Context;
using MediQueue.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediQueue.Infra.Repositories;

public class AtendimentoRepository : IAtendimentoRepository
{
    private readonly MediQueueContext _context;

    public AtendimentoRepository(MediQueueContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Atendimento>> GetAllAsync()
    {
        return await _context.Atendimentos
            .Include(x => x.Paciente)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Atendimento> GetByIdAsync(int id)
    {
        var atendimento = await _context.Atendimentos
            .Include(x => x.Paciente)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (atendimento == null)
            throw new InvalidOperationException("Atendimento não encontrado.");

        return atendimento;
    }

    public async Task<Atendimento> CreateAsync(Atendimento atendimento)
    {
        atendimento.NumeroSequencial = await GerarNumeroSequencialAsync();
        await _context.Atendimentos.AddAsync(atendimento);
        await _context.SaveChangesAsync();
        return atendimento;
    }

    public async Task<Atendimento> UpdateAsync(Atendimento atendimento)
    {
        var atendimentoEncontrado = await _context.Atendimentos.FindAsync(atendimento.Id);
        if (atendimentoEncontrado == null)
            throw new InvalidOperationException("Atendimento não encontrado.");

        _context.Entry(atendimentoEncontrado).CurrentValues.SetValues(atendimento);
        await _context.SaveChangesAsync();
        return atendimento;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var atendimento = await _context.Atendimentos.FindAsync(id);
        if (atendimento == null)
            return false;

        _context.Atendimentos.Remove(atendimento);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<int> GerarNumeroSequencialAsync()
    {
        var ultimoNumero = await _context.Atendimentos.MaxAsync(a => (int?)a.NumeroSequencial) ?? 0;
        return ultimoNumero + 1;
    }

    public async Task<List<Atendimento>> GetFilaAsync()
    {
        return await _context.Atendimentos
            .Include(x => x.Paciente)
            .AsNoTracking()
            .Where(a => a.Status == "Aguardando")
            .OrderBy(a => a.NumeroSequencial)
            .ToListAsync();
    }

    public async Task<Atendimento> ChamarProximoAsync()
    {
        var proximoAtendimento = await _context.Atendimentos
            .Include(x => x.Paciente)
            .AsNoTracking()
            .Where(a => a.Status == "Aguardando")
            .OrderBy(a => a.NumeroSequencial)
            .FirstOrDefaultAsync();

        if (proximoAtendimento == null)
            throw new InvalidOperationException("Nenhum atendimento na fila.");

        // Atualiza o status para "Em Atendimento"
        proximoAtendimento.Status = "Atendimento";


        _context.Atendimentos.Update(proximoAtendimento);
        await _context.SaveChangesAsync();

        return proximoAtendimento;
    }
}
