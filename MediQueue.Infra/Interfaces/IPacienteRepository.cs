using MediQueue.Domain.Entities;

namespace MediQueue.Infra.Interfaces;

public interface IPacienteRepository
{
    Task<IReadOnlyCollection<Paciente>> GetAllAsync();
    Task<Paciente> GetByIdAsync(int id);
    Task<Paciente> CreateAsync(Paciente paciente);
    Task<Paciente> UpdateAsync(Paciente paciente);
    Task<bool> DeleteAsync(int id);
}
