using testcqrs.Domain.Responses;
using MediatR;
using testcqrs.Domain.Contracts.Data;
using AutoMapper;
using testcqrs.Domain.Contracts.Data.Repositories;

namespace testcqrs.Application.Queries;
public class GetAllUserQuery : IRequest<IEnumerable<UserResponse>>
{

}

public class GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
	: IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
{
	private readonly IMapper _mapper = mapper;
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
	{
		var entities = await Task.FromResult(_unitOfWork.Repository<IUserRepository>().GetAll());

		return _mapper.Map<IEnumerable<UserResponse>>(entities);
	}
}