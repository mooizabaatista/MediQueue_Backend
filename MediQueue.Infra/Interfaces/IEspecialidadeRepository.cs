using MediQueue.Domain.Entities;

namespace MediQueue.Infra.Interfaces;

public interface IEspecialidadeRepository
{
    Task<IReadOnlyCollection<Especialidade>> GetAllAsync();
    Task<Especialidade> GetByIdAsync(int id);
}
