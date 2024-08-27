namespace testcqrs.ModuleName.Contracts.Data;

public interface IUnitOfWork
{
    public T Repository<T>() where T : notnull;
    public void Commit();
    public Task CommitAsync();
}