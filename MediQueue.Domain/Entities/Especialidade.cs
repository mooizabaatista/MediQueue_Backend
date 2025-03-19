using MediQueue.Domain.Base;

namespace MediQueue.Domain.Entities;

public sealed class Especialidade : EntityBase
{
    public string Nome { get; set; } = string.Empty;
}
