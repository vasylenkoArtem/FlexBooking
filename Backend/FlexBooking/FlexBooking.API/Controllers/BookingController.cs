using FlexBooking.Logic.Aggregates.Booking.Commands;
using FlexBooking.Logic.Aggregates.Booking.Models;
using FlexBooking.Logic.Aggregates.Booking.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController: ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command, [FromServices] IMediator mediator)
    {
        try
        {
            var bookingId = await mediator.Send(command);
            return Ok(bookingId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpGet("{bookingId:int}")]
    public async Task<IActionResult> GetBooking(int bookingId, [FromServices] IMediator mediator)
    {
        try
        {
            var query = new GetBookingQuery(bookingId);
            var booking = await mediator.Send(query);
            return Ok(booking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPut("{bookingId:int}")]
    public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] UpdateBookingViewModel viewModel,
        [FromServices] IMediator mediator)
    {
        try
        {
            var query = new UpdateBookingCommand(bookingId, viewModel);
            var booking = await mediator.Send(query);
            return Ok(booking);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}