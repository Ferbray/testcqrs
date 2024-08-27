using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Data;

public class CommonRepository<TEntity>(DatabaseContext context)
    : BaseRepository<TEntity>(context), ICommonRepository<TEntity>
    where TEntity : BaseEntity
{

}