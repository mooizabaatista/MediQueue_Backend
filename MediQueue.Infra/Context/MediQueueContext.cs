using MediQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediQueue.Infra.Context;

public class MediQueueContext : DbContext
{
    public MediQueueContext(DbContextOptions<MediQueueContext> options) : base(options) { }
    public MediQueueContext() { }


    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Triagem> Triagens { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediQueueContext).Assembly);
    }
}
