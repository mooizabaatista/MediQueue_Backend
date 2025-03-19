namespace MediQueue.Application.Dtos.Query;

public class AtendimentoQueryDto
{
    public int Id { get; set; }
    public int NumeroSequencial { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public string Status { get; set; } = string.Empty;

    // Relacionamento
    public PacienteQueryDto Paciente { get; set; } = default!;
}
