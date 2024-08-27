using AutoMapper;
using MediatR;
using testcqrs.ModuleName.Contracts.Data;

namespace testcqrs.ModuleName.Queries;

public abstract class BaseGetAllQuery<TResponse>
    : IRequest<IEnumerable<TResponse>>
{
}

public abstract class BaseGetAllQueryHandler<TR, TQ, TOM, TE>(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<TQ, IEnumerable<TOM>>
    where TQ : BaseGetAllQuery<TOM>
    where TR : IBaseRepository<TE>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public virtual async Task<IEnumerable<TOM>> Handle(TQ request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<TR>();
        var result = await Task.FromResult(repository.GetAll());

        return _mapper.Map<IEnumerable<TOM>>(result);
    }
}