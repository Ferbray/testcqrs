using Microsoft.EntityFrameworkCore;
using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Data;

public abstract class BaseRepository<TEntity>(DatabaseContext context)
    : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _set = context.Set<TEntity>();
    public IEnumerable<TEntity> GetAll() => [.. _set];

    public async Task<TEntity> SaveChanges(TEntity entity)
    {
        if (await _set.AnyAsync(u => u.Id == entity.Id))
        {
            _set.Update(entity);
        }
        else
        {
            await _set.AddAsync(entity);
        }

        return entity;
    }
}