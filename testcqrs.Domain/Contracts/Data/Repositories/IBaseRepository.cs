namespace testcqrs.Domain.Contracts.Data.Repositories;
public interface IBaseRepository<TEntity>
{
    public Task<TEntity> SaveChanges(TEntity entity);
    public IEnumerable<TEntity> GetAll();
}