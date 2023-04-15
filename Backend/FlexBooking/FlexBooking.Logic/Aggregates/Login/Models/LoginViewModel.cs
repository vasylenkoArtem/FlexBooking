using FlexBooking.Domain.Enums;

namespace FlexBooking.Logic.ViewModels;

public class LoginViewModel
{
    public int UserId { get; set; }
    public UserRoles RoleId { get; set; }
}