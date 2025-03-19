using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;

namespace MediQueue.Application.Interfaces;

public interface IAtendimentoService
{
    Task<IReadOnlyCollection<AtendimentoQueryDto>> GetAllAsync();
    Task<AtendimentoQueryDto> GetByIdAsync(int id);
    Task<AtendimentoQueryDto> CreateAsync(AtendimentoCommandDto atendimento);
    Task<AtendimentoQueryDto> UpdateAsync(AtendimentoCommandDto atendimento);
    Task<bool> DeleteAsync(int id);
    Task<List<AtendimentoQueryDto>> GetFilaAsync();
    Task<AtendimentoQueryDto> ChamarProximoAsync();
}
