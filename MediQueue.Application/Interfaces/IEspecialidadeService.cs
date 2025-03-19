using MediQueue.Application.Dtos.Query;

namespace MediQueue.Application.Interfaces;

public interface IEspecialidadeService
{
    Task<IReadOnlyCollection<EspecialidadeQueryDto>> GetAllAsync();
    Task<EspecialidadeQueryDto> GetByIdAsync(int id);
}
