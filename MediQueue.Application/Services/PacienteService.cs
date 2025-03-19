using AutoMapper;
using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;
using MediQueue.Domain.Entities;
using MediQueue.Infra.Interfaces;

namespace MediQueue.Application.Interfaces;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;

    public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
    {
        _pacienteRepository = pacienteRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<PacienteQueryDto>> GetAllAsync()
    {
        var pacientes = await _pacienteRepository.GetAllAsync();
        if (pacientes == null)
            throw new InvalidOperationException("Nenhum paciente encontrado.");

        return _mapper.Map<IReadOnlyCollection<PacienteQueryDto>>(pacientes);
    }

    public async Task<PacienteQueryDto> GetByIdAsync(int id)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Paciente não encontrado.");

        return _mapper.Map<PacienteQueryDto>(paciente);
    }

    public async Task<PacienteQueryDto> CreateAsync(PacienteCommandDto pacienteDto)
    {
        var paciente = _mapper.Map<Paciente>(pacienteDto);
        var pacienteCriado = await _pacienteRepository.CreateAsync(paciente);

        return _mapper.Map<PacienteQueryDto>(pacienteCriado);
    }

    public async Task<PacienteQueryDto> UpdateAsync(PacienteCommandDto pacienteDto)
    {
        var paciente = _mapper.Map<Paciente>(pacienteDto);
        var pacienteAtualizado = await _pacienteRepository.UpdateAsync(paciente);

        return _mapper.Map<PacienteQueryDto>(pacienteAtualizado);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _pacienteRepository.DeleteAsync(id);
    }
}
