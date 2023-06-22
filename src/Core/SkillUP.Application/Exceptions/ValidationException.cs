using FluentValidation.Results;

namespace SkillUP.Application.Exceptions;

public class ValidationException: Exception
{
    public List<string> Erros { get; set; }

    public ValidationException() : base("There have been one or more validation erros")
    {
        Erros = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Erros.Add(failure.ErrorMessage);
        }
    }

}
