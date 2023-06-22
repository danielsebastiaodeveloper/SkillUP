using SkillUP.Domain.Abstractions;

namespace SkillUP.Application.DTOs;

public class ClienteDTO: BaseDTO<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}
