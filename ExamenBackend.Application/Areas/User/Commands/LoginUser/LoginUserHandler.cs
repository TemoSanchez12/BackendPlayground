using ExamenBackend.Application.Areas.User.Models;
using ExamenBackend.Application.Models;
using ExamenBackend.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Text;
using UserApp = ExamenBackend.Domain.Models.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ExamenBackend.Application.Areas.User.Commands.LoginUser;

internal class LoginUserHandler(
    UserManager<UserApp> userManager,
    ILogger<LoginUserHandler> logger,
    IConfiguration configuration
) : IRequestHandler<LoginUserCommand, ApiResponse<UserLoginResponseDto>>
{
    public async Task<ApiResponse<UserLoginResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Login user with email {Email}", request.Email);

        var user = await userManager.FindByEmailAsync(request.Email);


        if (user == null)
            throw new NotFoundException(nameof(user).ToString(), request.Email);

        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
            throw new UnauthorizedAccessException($"Wrong login credentials for email{request.Email}");

        var token = await GenerateJwtToken(user, request.RememberMe);

        return new ApiResponse<UserLoginResponseDto>
        {
            Success = true,
            Message = "User login successfully",
            Data = new UserLoginResponseDto
            {
                UserName = user.UserName!,
                Email = user.Email!,
                Id = Guid.Parse(user.Id),
                Token = token
            }
        };
    }

    private async Task<string> GenerateJwtToken(UserApp user, bool rememberMe)
    {
        var userRoles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"] ?? string.Empty)); // Debes configurar esta clave en tu appsettings
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims, issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            expires: DateTime.Now.AddHours(rememberMe ? 720 : 2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
