using AutoMapper;
using MediQueue.Application.Dtos.Command;
using MediQueue.Application.Dtos.Query;
using MediQueue.Domain.Entities;

namespace MediQueue.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Paciente Map
        CreateMap<Paciente, PacienteQueryDto>().ReverseMap();
        CreateMap<Paciente, PacienteCommandDto>().ReverseMap();
        CreateMap<PacienteQueryDto,  PacienteCommandDto>().ReverseMap();

        // Atendimento
        CreateMap<Atendimento, AtendimentoQueryDto>().ReverseMap();
        CreateMap<Atendimento, AtendimentoCommandDto>().ReverseMap();
        CreateMap<AtendimentoQueryDto, AtendimentoCommandDto>().ReverseMap();

        // Triagem
        CreateMap<Triagem, TriagemQueryDto>().ReverseMap();
        CreateMap<Triagem, TriagemCommandDto>().ReverseMap();
        CreateMap<TriagemQueryDto, TriagemCommandDto>().ReverseMap();

        // Especialidade
        CreateMap<Especialidade, EspecialidadeQueryDto>().ReverseMap();
    }
}
