using UserApp = ExamenBackend.Domain.Models.User;
using ExamenBackend.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FluentValidation;
using ExamenBackend.Domain.Exceptions;

namespace ExamenBackend.Application.Areas.User.Commands.UpdateUser;

internal class UpdateUserHandler(
    ILogger<UpdateUserHandler> logger,
    IUserStore<UserApp> userStore
) : IRequestHandler<UpdateUserCommand, ApiResponse<object>>
{
    public async Task<ApiResponse<object>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating user wiht name {FirstName} {LastName}", request.FirstName, request.LastName);


        var validator = new UpdateUserValidator();
        validator.ValidateAndThrow(request);

        var user = await userStore.FindByIdAsync(request.Id, cancellationToken);

        if (user == null)
            throw new NotFoundException(nameof(user), request.Id);


        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.SecondLastName = request.SecondLastName;
        user.MiddleName = request.MiddleName;
        user.BirthDate = request.BirthDate;


        try
        {
            await userStore.UpdateAsync(user, cancellationToken);
            return new ApiResponse<object>
            {
                Success = true,
                Message = "User updated correctly"
            };
        }
        catch (Exception ex)
        {
            {
                logger.LogError("Something went wrong while updating the user {Ex}", ex);
                throw new Exception("Something went wrong while updating user");
            }



        }
    }
}
