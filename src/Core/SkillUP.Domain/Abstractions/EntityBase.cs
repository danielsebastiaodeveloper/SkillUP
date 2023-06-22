using SkillUP.Domain.Interfaces;

namespace SkillUP.Domain.Abstractions;

public abstract class EntityBase<Tkey, TUserKey> : IEntityBase<Tkey, TUserKey>
{
    public Tkey Id { get ; set ; } = default!;
    public TUserKey CreatedBy { get; set; } = default!;
    public DateTime CreatedAt { get ; set ; }
    public bool State { get ; set ; }

}
