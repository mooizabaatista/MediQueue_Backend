using FluentValidation;
using MediQueue.Application.Dtos.Command;

namespace MediQueue.Application.Validations;

public class PacienteValidator : AbstractValidator<PacienteCommandDto>
{
    public PacienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Campo nome é obrigatório")
            .MinimumLength(3).WithMessage("Campo nome deve ter no mínimo 3 caracteres")
            .MaximumLength(150).WithMessage("Campo nome deve ter no máximo 150 caracteres");

        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("Campo telefone é obrigatório")
            .MaximumLength(15).WithMessage("Campo telefone deve ter no máximo 15 caracteres");

        RuleFor(x => x.Sexo)
            .NotEmpty().WithMessage("Campo sexo é obrigatório");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Campo email é obrigatório")
            .EmailAddress().WithMessage("Campo email está num formato inválido")
            .MaximumLength(150).WithMessage("Campo email deve ter no máximo 150 caracteres");
    }
}
