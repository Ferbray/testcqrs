using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using testcqrs.Application.Commands;
using testcqrs.Application.Queries;
using testcqrs.Domain.Requests;
using testcqrs.Domain.Responses;

namespace testcqrs.WebApi.Controllers;

[Route("api/user")]
public class UserController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllUserQuery();

        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post([FromBody] UserRequest request)
    {
        var command = new CreateUserCommand(request);

        var response = await _mediator.Send(command);

        return StatusCode((int)HttpStatusCode.Created, response);
    }
}