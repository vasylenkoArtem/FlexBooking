using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Aggregates.Login.Commands;

public class RegisterCommand : IRequest<LoginViewModel>
{
    public string Username { get; set; }
    public string Password { get; set; }

    public RegisterCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}