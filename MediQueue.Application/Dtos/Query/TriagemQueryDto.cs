namespace MediQueue.Application.Dtos.Query;

public class TriagemQueryDto
{
    public int Id { get; set; }
    public string Sintomas { get; set; } = string.Empty;
    public double PressaoArterial { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    // Relacionamento
    public EspecialidadeQueryDto Especialidade { get; set; } = default!;
    public AtendimentoQueryDto Atendimento { get; set; } = default!;
}
