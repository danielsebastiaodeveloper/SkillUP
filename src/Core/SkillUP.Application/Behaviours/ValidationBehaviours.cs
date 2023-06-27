using FluentValidation;
using MediatR;

namespace SkillUP.Application.Behaviours;

public class ValidationBehaviours<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any()) 
        {
            var contexto = new FluentValidation.ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll( validators.Select( v => v.ValidateAsync(contexto, cancellationToken)));
            var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count !=0 )
            {
                throw new ValidationException(failures);
            }
        }
        return await next();
    }
}
