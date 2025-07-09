using Application.Features.User.Commands.LoginUser;
using Application.Features.User.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Login an existing user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
            var token = await _mediator.Send(command);
            return Ok(new { token });
    }
    
    /// <summary>
    /// Register a new user
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        
            var userId = await _mediator.Send(command);
            return Ok(new { userId });
    }
}