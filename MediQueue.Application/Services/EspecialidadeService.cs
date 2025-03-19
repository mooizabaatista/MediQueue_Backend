using AutoMapper;
using MediQueue.Application.Dtos.Query;
using MediQueue.Infra.Interfaces;

namespace MediQueue.Application.Interfaces;

public class EspecialidadeService : IEspecialidadeService
{
    private readonly IEspecialidadeRepository _especialidadeRepository;
    private readonly IMapper _mapper;

    public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IMapper mapper)
    {
        _especialidadeRepository = especialidadeRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<EspecialidadeQueryDto>> GetAllAsync()
    {
        var especialidades = await _especialidadeRepository.GetAllAsync();
        if (especialidades == null || especialidades.Count == 0)
            throw new InvalidOperationException("Nenhuma especialidade encontrada.");

        return _mapper.Map<IReadOnlyCollection<EspecialidadeQueryDto>>(especialidades);
    }

    public async Task<EspecialidadeQueryDto> GetByIdAsync(int id)
    {
        var especialidade = await _especialidadeRepository.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Especialidade não encontrada.");

        return _mapper.Map<EspecialidadeQueryDto>(especialidade);
    }
}
