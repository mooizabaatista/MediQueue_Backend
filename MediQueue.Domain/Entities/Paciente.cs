using MediQueue.Domain.Base;

namespace MediQueue.Domain.Entities;

public sealed class Paciente : EntityBase
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
