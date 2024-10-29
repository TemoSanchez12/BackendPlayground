using ExamenBackend.Application.Models;
using MediatR;

namespace ExamenBackend.Application.Areas.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<ApiResponse<object>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string SecondLastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
