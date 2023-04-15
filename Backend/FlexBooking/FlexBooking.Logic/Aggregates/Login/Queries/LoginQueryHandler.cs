using FlexBooking.Domain;
using FlexBooking.Logic.Queries;
using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Handlers;

public class LoginQueryHandler: IRequestHandler<LoginQuery, LoginViewModel>
{
    private readonly IFlexBookingContext _context;

    public LoginQueryHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = _context.Users?.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
        
        if (user == null)
        {
            throw new Exception("Invalid username or password");
        }

        return Task.FromResult(new LoginViewModel
        {
            UserId = user.Id,
            RoleId = user.RoleId
        });
    }
}