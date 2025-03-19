using MediQueue.Domain.Base;

namespace MediQueue.Domain.Entities;

public sealed class Triagem : EntityBase
{
    public string Sintomas { get; set; } = string.Empty;
    public double PressaoArterial { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    // Relacionamento
    public int EspecialidadeId { get; set; }
    public Especialidade Especialidade { get; set; } = default!;

    public int AtendimentoId { get; set; }
    public Atendimento Atendimento { get; set; } = default!;
}
