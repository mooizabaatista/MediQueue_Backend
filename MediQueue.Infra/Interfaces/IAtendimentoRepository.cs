using MediQueue.Domain.Entities;

namespace MediQueue.Infra.Interfaces;

public interface IAtendimentoRepository
{
    Task<IReadOnlyCollection<Atendimento>> GetAllAsync();
    Task<Atendimento>GetByIdAsync(int id);
    Task<Atendimento>CreateAsync(Atendimento atendimento);
    Task<Atendimento>UpdateAsync(Atendimento atendimento);
    Task<bool>DeleteAsync(int id);
    Task<List<Atendimento>> GetFilaAsync();
    Task<Atendimento> ChamarProximoAsync();
}
