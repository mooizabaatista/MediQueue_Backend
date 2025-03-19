using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;

namespace MediQueue.Application.Interfaces;

public interface IPacienteService
{
    Task<IReadOnlyCollection<PacienteQueryDto>> GetAllAsync();
    Task<PacienteQueryDto> GetByIdAsync(int id);
    Task<PacienteQueryDto> CreateAsync(PacienteCommandDto paciente);
    Task<PacienteQueryDto> UpdateAsync(PacienteCommandDto paciente);
    Task<bool> DeleteAsync(int id);
}
