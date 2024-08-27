using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Contracts.Data;

public interface ICommonRepository<TEntity>
    : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{

}