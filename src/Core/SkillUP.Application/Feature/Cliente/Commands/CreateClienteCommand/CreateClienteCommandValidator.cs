using FluentValidation;

namespace SkillUP.Application.Feature.Cliente.Commands.CreateClienteCommand;

public class CreateClienteCommandValidator: AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .WithMessage("{PropertyName} can not be null")
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters");

        RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid e-mail");
    }
}
