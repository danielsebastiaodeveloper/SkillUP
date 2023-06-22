using FluentValidation;

namespace SkillUP.Application.Feature.Cliente.Queries.GetClienteById;

public class GetClienteByIdQueryValidator: AbstractValidator<GetClienteByIdQuery>
{
    public GetClienteByIdQueryValidator()
    {
        RuleFor( c=> c.Id )
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty")
            .NotNull()
            .WithMessage("{PropertyName} can not be null");
    }
}
