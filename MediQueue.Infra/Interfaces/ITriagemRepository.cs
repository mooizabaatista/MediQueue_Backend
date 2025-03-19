using MediQueue.Domain.Entities;

namespace MediQueue.Infra.Interfaces;

public interface ITriagemRepository
{
    Task<IReadOnlyCollection<Triagem>> GetAllAsync();
    Task<Triagem> GetByIdAsync(int id);
    Task<Triagem> CreateAsync(Triagem triagem);
    Task<Triagem> UpdateAsync(Triagem triagem);
    Task<bool> DeleteAsync(int id);
}
