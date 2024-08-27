namespace testcqrs.ModuleName.Contracts.Data;

public interface IBaseRepository<TEntity>
{
    public Task<TEntity> SaveChanges(TEntity entity);
    public IEnumerable<TEntity> GetAll();
}