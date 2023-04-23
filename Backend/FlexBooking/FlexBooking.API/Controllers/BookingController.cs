using FlexBooking.Logic.Aggregates.Booking.Commands;
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
    public IActionResult UpdateBooking(int bookingId)
    {
        // Mark as updated and update
        return Ok();
    }
    
    [HttpDelete("{bookingId:int}")]
    public IActionResult DeleteBooking(int bookingId)
    {
        // Mark as deleted
        return Ok();
    }
}