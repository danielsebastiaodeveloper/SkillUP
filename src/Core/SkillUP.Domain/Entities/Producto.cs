using SkillUP.Domain.Abstractions;

namespace SkillUP.Domain.Entities;

public class Producto: EntityBase<Guid, Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
