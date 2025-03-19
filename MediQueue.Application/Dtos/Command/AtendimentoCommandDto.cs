namespace MediQueue.Application.Dtos.Command;

public class AtendimentoCommandDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;

    // Relacionamento
    public int PacienteId { get; set; }
}
