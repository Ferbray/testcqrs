using AutoMapper;
using testcqrs.ModuleName.Responses;
using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Queries;

public class GetAllUserQuery : BaseGetAllQuery<UserResponse>
{
}

public class GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
	: BaseGetAllQueryHandler<IUserRepository, GetAllUserQuery, UserResponse, UserEntity>(mapper, unitOfWork)
{
}