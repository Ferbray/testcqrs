using MediatR;
using Microsoft.AspNetCore.Mvc;
using testcqrs.ModuleName.Requests;
using testcqrs.ModuleName.Responses;

namespace testcqrs.ModuleName.Controllers;

[Route("api/user")]
public class UserController(IMediator mediator)
    : BaseController<UserRequest, UserResponse>(mediator)
{
}