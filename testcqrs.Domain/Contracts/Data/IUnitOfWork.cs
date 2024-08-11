using testcqrs.Domain.Contracts.Data.Repositories;

namespace testcqrs.Domain.Contracts.Data;
public interface IUnitOfWork
{
    public T Repository<T>() where T : notnull;
    public Task Commit();
}