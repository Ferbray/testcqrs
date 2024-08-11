using Microsoft.EntityFrameworkCore;
using testcqrs.Domain.Contracts.Data.Repositories;
using testcqrs.Domain.Entities;

namespace testcqrs.DataAccess.Repositories;
public class UserRepository(DatabaseContext context) : IUserRepository
{
    private readonly DbSet<UserEntity> _userSet = context.Set<UserEntity>();

    public IEnumerable<UserEntity> GetAll() => [.. _userSet];

    public async Task<bool> SaveChanges(UserEntity user)
    {
        if (await _userSet.AnyAsync(u => u.Id == user.Id))
        {
            _userSet.Update(user);
        }
        else
        {
            await _userSet.AddAsync(user);
        }

        return true;
    }
}