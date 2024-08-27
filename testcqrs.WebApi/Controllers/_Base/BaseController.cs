using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using testcqrs.ModuleName.Commands;
using testcqrs.ModuleName.Queries;

namespace testcqrs.ModuleName.Controllers;

public abstract class BaseController<TIM, TOM>(IMediator mediator)
    : ControllerBase
{
    protected readonly IMediator _mediator = mediator;

    [HttpGet("all")]
    public virtual async Task<IActionResult> GetAll()
    {
        var query = CreateInstanceForMediator<BaseGetAllQuery<TOM>>();

        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    public virtual async Task<IActionResult> Post([FromBody] TIM request)
    {
        var command = CreateInstanceForMediator<BaseCreateCommand<TIM, TOM>>(request);

        var response = await _mediator.Send(command);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    private static object CreateInstanceForMediator<TBaseType>(params object?[] args)
    {
        var baseType = typeof(TBaseType);
        var assembly = baseType.Assembly;
        var type = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(baseType))
            .FirstOrDefault() ?? throw new Exception("Not class for mediator");

        return Activator.CreateInstance(type, args) ??
            throw new Exception("Not class for mediator");
    }
}