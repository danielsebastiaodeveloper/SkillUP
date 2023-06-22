using SkillUP.Domain.Interfaces;

namespace SkillUP.Domain.Abstractions;

public abstract class BaseDTO<TKey> : IBase<TKey>
{
    public TKey Id { get; set; } = default!;
}
