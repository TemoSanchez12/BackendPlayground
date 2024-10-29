using ExamenBackend.Application.Areas.User.Commands.CreateUser;
using ExamenBackend.Application.Areas.User.Commands.LoginUser;
using ExamenBackend.Application.Areas.User.Commands.UpdateUser;
using ExamenBackend.Application.Areas.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamenBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("get-users/{query}")]
    public async Task<IActionResult> GetUsers([FromRoute] string query)
    {
        var response = await mediator.Send(new GetUsersQuery { Query = query });
        return Ok(response);
    }
}
