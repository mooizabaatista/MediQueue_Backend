using AutoMapper;
using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;
using MediQueue.Domain.Entities;
using MediQueue.Infra.Interfaces;

namespace MediQueue.Application.Interfaces;

public class AtendimentoService : IAtendimentoService
{
    private readonly IAtendimentoRepository _atendimentoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;

    public AtendimentoService(
        IAtendimentoRepository atendimentoRepository,
        IMapper mapper,
        IPacienteRepository pacienteRepository)
    {
        _atendimentoRepository = atendimentoRepository;
        _mapper = mapper;
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IReadOnlyCollection<AtendimentoQueryDto>> GetAllAsync()
    {
        var atendimentos = await _atendimentoRepository.GetAllAsync();
        if (atendimentos == null)
            throw new InvalidOperationException("Nenhum atendimento encontrado.");

        return _mapper.Map<IReadOnlyCollection<AtendimentoQueryDto>>(atendimentos);
    }

    public async Task<AtendimentoQueryDto> GetByIdAsync(int id)
    {
        var atendimento = await _atendimentoRepository.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Atendimento não encontrado.");

        return _mapper.Map<AtendimentoQueryDto>(atendimento);
    }

    public async Task<AtendimentoQueryDto> CreateAsync(AtendimentoCommandDto atendimentoDto)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(atendimentoDto.PacienteId)
            ?? throw new InvalidOperationException("Informe um paciente válido.");

        var atendimento = _mapper.Map<Atendimento>(atendimentoDto);
        atendimento.DataHoraChegada = DateTime.Now;

        var atendimentoCriado = await _atendimentoRepository.CreateAsync(atendimento);
        return _mapper.Map<AtendimentoQueryDto>(atendimentoCriado);
    }

    public async Task<AtendimentoQueryDto> UpdateAsync(AtendimentoCommandDto atendimentoDto)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(atendimentoDto.PacienteId)
            ?? throw new InvalidOperationException("Informe um paciente válido.");

        var atendimento = _mapper.Map<Atendimento>(atendimentoDto);
        var atendimentoAtualizado = await _atendimentoRepository.UpdateAsync(atendimento);

        return _mapper.Map<AtendimentoQueryDto>(atendimentoAtualizado);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _atendimentoRepository.DeleteAsync(id);
    }

    public async Task<List<AtendimentoQueryDto>> GetFilaAsync()
    {
        var fila = await _atendimentoRepository.GetFilaAsync();
        if (fila == null)
            throw new InvalidOperationException("Erro ao buscar a fila de atendimentos.");

        return _mapper.Map<List<AtendimentoQueryDto>>(fila);
    }

    public async Task<AtendimentoQueryDto> ChamarProximoAsync()
    {
        var proximo = await _atendimentoRepository.ChamarProximoAsync()
            ?? throw new InvalidOperationException("Erro ao chamar o próximo atendimento.");

        return _mapper.Map<AtendimentoQueryDto>(proximo);
    }
}
