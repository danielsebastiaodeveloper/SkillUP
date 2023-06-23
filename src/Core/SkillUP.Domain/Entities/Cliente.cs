using SkillUP.Domain.Abstractions;

namespace SkillUP.Domain.Entities;

public class Cliente : EntityBase<long, long>
{
    public required string Name { get; set; }
    public required string Email { get; set; }

}
