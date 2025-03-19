namespace MediQueue.Application.Dtos.Command;

public class TriagemCommandDto
{
    public int Id { get; set; }
    public string Sintomas { get; set; } = string.Empty;
    public double? PressaoArterial { get; set; }
    public double? Peso { get; set; }
    public double? Altura { get; set; }

    // Relacionamento
    public int EspecialidadeId { get; set; }
    public int AtendimentoId { get; set; }
}
