using AutoMapper;
using MediatR;
using testcqrs.Domain.Contracts.Data;
using testcqrs.Domain.Contracts.Data.Repositories;

namespace testcqrs.Application.Commands;

public abstract class BaseCreateCommand<TRequest, TResponse>(TRequest request)
    : IRequest<TResponse>
{
    public readonly TRequest Request = request;
}

public abstract class BaseCreateCommandHandler<TR, TC, TIM, TOM, TE>(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<TC, TOM>
    where TC : BaseCreateCommand<TIM, TOM>
    where TR : IBaseRepository<TE>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public virtual async Task<TOM> Handle(TC command, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<TR>();
        var result = await repository.SaveChanges(_mapper.Map<TE>(command.Request));
        await _unitOfWork.Commit();

        return _mapper.Map<TOM>(result);
    }
}