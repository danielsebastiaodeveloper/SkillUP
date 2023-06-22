namespace SkillUP.Domain.Interfaces;

public interface IAuditableEntityBase<TKey, TUserKey>: IEntityBase<TKey, TUserKey>
{
    public TUserKey UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}
