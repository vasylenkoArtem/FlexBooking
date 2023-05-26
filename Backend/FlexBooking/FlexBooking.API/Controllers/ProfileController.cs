using FlexBooking.Logic.Aggregates.Login.Commands;
using FlexBooking.Logic.DTOs;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("/api/profile")]
public class ProfileController: ControllerBase
{
    // POST: api/profile/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto, [FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new LoginQuery(loginDto.Username, loginDto.Password));
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    // POST: api/profile/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginDTO registerDto, [FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new RegisterCommand(registerDto.Username, registerDto.Password));
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}