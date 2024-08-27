using AutoMapper;
using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Entities;
using testcqrs.ModuleName.Requests;
using testcqrs.ModuleName.Responses;

namespace testcqrs.ModuleName.Commands;

public class CreateUserCommand(UserRequest request)
    : BaseCreateCommand<UserRequest, UserResponse>(request)
{
}

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : BaseCreateCommandHandler<
        ICommonRepository<UserEntity>,
        CreateUserCommand,
        UserRequest,
        UserResponse,
        UserEntity>(unitOfWork, mapper)
{
}