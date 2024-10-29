using ExamenBackend.Application.Models;
using ExamenBackend.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using AppUser = ExamenBackend.Domain.Models.User;

namespace ExamenBackend.Application.Areas.User.Commands.CreateUser;

internal class CreateUserHandler(
    ILogger<CreateUserHandler> logger,
    UserManager<AppUser> userManager
) : IRequestHandler<CreateUserCommand, ApiResponse<object>>
{
    public async Task<ApiResponse<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating user with name {FirstName} {LastName}", request.FirstName, request.LastName);

        var validator = new CreateUserValidator();
        validator.ValidateAndThrow(request);


        var user = new AppUser
        {
            UserName = (request.FirstName + request.LastName).ToLower().Replace(" ", ""),
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            SecondLastName = request.SecondLastName,
            BirthDate = request.BirthDate,
            Email = request.Email,
            EmailConfirmed = true,
            RegiterAt = DateTime.UtcNow,
        };

        try
        {
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                logger.LogError("Error while creating user {Error}", result.Errors.ToString());
                throw new Exception("Something went wrong while creating user)");
            }

            return new ApiResponse<object>
            {
                Success = true,
                Message = "Usuario creado con exito",
            };
        } catch (Exception ex)
        {
            logger.LogError("Something went wrong while creating user, {Ex}", ex);
            throw new SaveUserException(request.FirstName);
        }



    }
}
