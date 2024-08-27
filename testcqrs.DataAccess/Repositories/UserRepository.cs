using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Data;

public class UserRepository(DatabaseContext context)
    : BaseRepository<UserEntity>(context), IUserRepository
{
}