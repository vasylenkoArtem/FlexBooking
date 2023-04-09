using FlexBooking.Logic.ViewModels;
using MediatR;

namespace FlexBooking.Logic.Queries;

public class LoginQuery : IRequest<LoginViewModel>
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public LoginQuery(string username, string password)
    {
        Username = username;
        Password = password;
    }
}