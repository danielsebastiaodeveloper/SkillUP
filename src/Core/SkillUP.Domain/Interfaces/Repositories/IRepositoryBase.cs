namespace SkillUP.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TKey, TUserKey, TEntity> where TEntity : class, IEntityBase<TKey, TUserKey> //Restricciones
{
    Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(TEntity entity, TKey Id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(TKey Id, CancellationToken cancellationToken = default);

    Task<TEntity> GetEntityByIdAsync(TKey Id, CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllEntitiesAsync(object? param, CancellationToken cancellationToken = default);

}
