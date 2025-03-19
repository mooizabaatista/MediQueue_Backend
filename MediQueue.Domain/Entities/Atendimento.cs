using MediQueue.Domain.Base;

namespace MediQueue.Domain.Entities;

public sealed class Atendimento : EntityBase
{
    public int NumeroSequencial { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public string Status { get; set; } = string.Empty;

    // Relacionamento
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; } = default!;
}
