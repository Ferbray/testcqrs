using AutoMapper;
using MediatR;
using testcqrs.Domain.Contracts.Data;
using testcqrs.Domain.Contracts.Data.Repositories;
using testcqrs.Domain.Entities;
using testcqrs.Domain.Requests;

namespace testcqrs.Application.Commands;
public class CreateUserCommand(UserRequest request) : IRequest<bool>
{
    public readonly UserRequest Request = request;
}

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Repository<IUserRepository>()
                         .SaveChanges(_mapper.Map<UserEntity>(request.Request));
        await _unitOfWork.Commit();

        return true;
    }
}