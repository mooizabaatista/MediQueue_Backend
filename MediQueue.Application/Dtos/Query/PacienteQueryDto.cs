﻿namespace MediQueue.Application.Dtos.Query;

public class PacienteQueryDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
