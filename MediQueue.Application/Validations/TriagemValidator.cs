using FluentValidation;
using MediQueue.Application.Dtos.Command;

namespace MediQueue.Application.Validations;

public class TriagemValidator : AbstractValidator<TriagemCommandDto>
{
    public TriagemValidator()
    {
        RuleFor(x => x.Sintomas)
            .NotEmpty().WithMessage("Campo sintomas é obrigatório")
            .MinimumLength(3).WithMessage("Campo sintomas deve ter no mínimo 3 caracteres")
            .MaximumLength(500).WithMessage("Campo sintomas deve ter no máximo 500 caracteres");

        RuleFor(x => x.PressaoArterial)
            .NotEmpty().WithMessage("Campo pressão arterial é obrigatório")
            .GreaterThan(0).WithMessage("Informe um valor válido para a pressão arterial");

        RuleFor(x => x.Peso)
           .NotEmpty().WithMessage("Campo peso é obrigatório")
           .GreaterThan(0).WithMessage("Informe um valor válido para o peso");

        RuleFor(x => x.Altura)
           .NotEmpty().WithMessage("Campo altura é obrigatório")
           .GreaterThan(0).WithMessage("Informe um valor válido para a altura");
    }
}
