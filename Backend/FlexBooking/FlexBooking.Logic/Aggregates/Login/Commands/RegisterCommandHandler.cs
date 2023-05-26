using FlexBooking.Domain;
using FlexBooking.Domain.Enums;
using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Login.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginViewModel>
{
    private readonly IFlexBookingContext _context;

    public RegisterCommandHandler(IFlexBookingContext context)
    {
        _context = context;
    }
    
    public async Task<LoginViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var newUser = new Domain.Models.User
        {
            Username = request.Username,
            Password = request.Password,
            RoleId = UserRoles.Client
        };
        
        _context.Users?.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new LoginViewModel
        {
            RoleId = UserRoles.Client,
            UserId = newUser.Id
        };
    }
}