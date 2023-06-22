namespace SkillUP.Domain.Interfaces;

public interface IBase<TKey>
{
    public TKey Id { get; set; }
}
