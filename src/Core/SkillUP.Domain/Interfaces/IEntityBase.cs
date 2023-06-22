namespace SkillUP.Domain.Interfaces;

public interface IEntityBase<TKey, TUserKey>: IBase<TKey>
{
    public TUserKey CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool State { get; set; }

}


