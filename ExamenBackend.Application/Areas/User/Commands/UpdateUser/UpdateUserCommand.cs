using ExamenBackend.Application.Models;
using MediatR;

namespace ExamenBackend.Application.Areas.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ApiResponse<object>>
{

    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string SecondLastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
