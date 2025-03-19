using MediQueue.Application.AutoMapper;
using MediQueue.Application.Interfaces;
using MediQueue.Infra.Context;
using MediQueue.Infra.Interfaces;
using MediQueue.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediQueue.IoC;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
    {
        // Contexto
        services.AddDbContext<MediQueueContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        // Repositorios
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
        services.AddScoped<ITriagemRepository, TriagemRepository>();
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

        // Services
        services.AddScoped<IPacienteService, PacienteService>();
        services.AddScoped<IAtendimentoService, AtendimentoService>();
        services.AddScoped<ITriagemService, TriagemService>();
        services.AddScoped<IEspecialidadeService, EspecialidadeService>();

        return services;
    }
}
