using SkillUP.Domain.Interfaces;

namespace SkillUP.Domain.Abstractions;

public class AuditableEntityBase<TKey, TUserKey> : EntityBase<TKey, TUserKey>, IAuditableEntityBase<TKey, TUserKey>
{
    public TUserKey UpdatedBy { get; set; } = default!;
    public DateTime UpdatedAt { get ; set ; }
}
