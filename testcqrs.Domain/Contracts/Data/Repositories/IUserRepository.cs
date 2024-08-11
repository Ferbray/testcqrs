using testcqrs.Domain.Entities;

namespace testcqrs.Domain.Contracts.Data.Repositories;
public interface IUserRepository
{
    public Task<bool> SaveChanges(UserEntity user);
    public IEnumerable<UserEntity> GetAll();
}