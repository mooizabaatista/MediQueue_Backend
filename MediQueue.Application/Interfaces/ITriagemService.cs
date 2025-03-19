using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;

namespace MediQueue.Application.Interfaces;

public interface ITriagemService
{
    Task<IReadOnlyCollection<TriagemQueryDto>> GetAllAsync();
    Task<TriagemQueryDto> GetByIdAsync(int id);
    Task<TriagemQueryDto> CreateAsync(TriagemCommandDto triagem);
    Task<TriagemQueryDto> UpdateAsync(TriagemCommandDto triagem);
    Task<bool> DeleteAsync(int id);
}
