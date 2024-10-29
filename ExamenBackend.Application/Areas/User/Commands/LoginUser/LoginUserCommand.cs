using ExamenBackend.Application.Areas.User.Models;
using ExamenBackend.Application.Models;
using MediatR;

namespace ExamenBackend.Application.Areas.User.Commands.LoginUser;

public class LoginUserCommand : IRequest<ApiResponse<UserLoginResponseDto>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}
