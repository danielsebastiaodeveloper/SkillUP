using FluentValidation;

namespace SkillUP.Application.Feature.Cliente.Commands.UpdateClienteCommand;

public class UpdateClienteCommandValidator: AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteCommandValidator()
    {
        RuleFor(c => c.Id)
          .NotNull()
          .WithMessage("{PropertyName} is required.");

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
