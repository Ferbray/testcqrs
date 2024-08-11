using AutoMapper;
using testcqrs.Domain.Responses;
using testcqrs.Domain.Contracts.Data;
using testcqrs.Domain.Contracts.Data.Repositories;
using testcqrs.Domain.Entities;

namespace testcqrs.Application.Queries;
public class GetAllUserQuery : BaseGetAllQuery<UserResponse>
{
}

public class GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
	: BaseGetAllQueryHandler<IUserRepository, GetAllUserQuery, UserResponse, UserEntity>(mapper, unitOfWork)
{
}