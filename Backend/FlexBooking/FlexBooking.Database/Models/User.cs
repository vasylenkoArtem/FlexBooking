using System.ComponentModel.DataAnnotations;
using FlexBooking.Domain.Enums;

namespace FlexBooking.Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRoles RoleId { get; set; }
}