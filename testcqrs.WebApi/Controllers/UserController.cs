using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using testcqrs.ModuleName.Commands;
using testcqrs.ModuleName.Queries;
using testcqrs.ModuleName.Requests;
using testcqrs.ModuleName.Responses;

namespace testcqrs.ModuleName.Controllers;

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