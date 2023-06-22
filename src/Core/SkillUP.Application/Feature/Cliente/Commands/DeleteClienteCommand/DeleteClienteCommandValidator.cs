using FluentValidation;

namespace SkillUP.Application.Feature.Cliente.Commands.DeleteClienteCommand;

public class DeleteClienteCommandValidator: AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}
