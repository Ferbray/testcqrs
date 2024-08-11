using AutoMapper;
using MediatR;
using testcqrs.Domain.Contracts.Data;
using testcqrs.Domain.Contracts.Data.Repositories;
using testcqrs.Domain.Entities;
using testcqrs.Domain.Requests;
using testcqrs.Domain.Responses;

namespace testcqrs.Application.Commands;
public class CreateUserCommand(UserRequest request)
    : BaseCreateCommand<UserRequest, UserResponse>(request)
{
}

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : BaseCreateCommandHandler<
        IUserRepository,
        CreateUserCommand,
        UserRequest,
        UserResponse,
        UserEntity>(unitOfWork, mapper)
{
}