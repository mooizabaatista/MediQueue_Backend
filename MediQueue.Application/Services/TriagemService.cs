using AutoMapper;
using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;
using MediQueue.Domain.Entities;
using MediQueue.Infra.Interfaces;

namespace MediQueue.Application.Interfaces;

public class TriagemService : ITriagemService
{
    private readonly ITriagemRepository _triagemRepository;
    private readonly IMapper _mapper;

    public TriagemService(ITriagemRepository triagemRepository, IMapper mapper)
    {
        _triagemRepository = triagemRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<TriagemQueryDto>> GetAllAsync()
    {
        var triagens = await _triagemRepository.GetAllAsync();
        if (triagens == null || triagens.Count == 0)
            throw new InvalidOperationException("Nenhuma triagem encontrada.");

        return _mapper.Map<IReadOnlyCollection<TriagemQueryDto>>(triagens);
    }

    public async Task<TriagemQueryDto> GetByIdAsync(int id)
    {
        var triagem = await _triagemRepository.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Triagem não encontrada.");

        return _mapper.Map<TriagemQueryDto>(triagem);
    }

    public async Task<TriagemQueryDto> CreateAsync(TriagemCommandDto triagemDto)
    {
        var triagem = _mapper.Map<Triagem>(triagemDto);
        var triagemCriada = await _triagemRepository.CreateAsync(triagem);

        return _mapper.Map<TriagemQueryDto>(triagemCriada);
    }

    public async Task<TriagemQueryDto> UpdateAsync(TriagemCommandDto triagemDto)
    {
        var triagem = _mapper.Map<Triagem>(triagemDto);
        var triagemAtualizada = await _triagemRepository.UpdateAsync(triagem);

        return _mapper.Map<TriagemQueryDto>(triagemAtualizada);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _triagemRepository.DeleteAsync(id);
    }
}
