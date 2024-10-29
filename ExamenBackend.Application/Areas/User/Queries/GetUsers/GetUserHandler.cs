using ExamenBackend.Application.Areas.User.Models;
using ExamenBackend.Application.Models;
using ExamenBackend.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ExamenBackend.Application.Areas.User.Queries.GetUsers;

internal class GetUsersHandler(
    ILogger<GetUsersHandler> logger,
    IUserRepository userRepository
) : IRequestHandler<GetUsersQuery, ApiResponse<List<UserDto>>>
{
    public async Task<ApiResponse<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all users with query {Query}", request.Query);

        var users = await userRepository.GetUsersAsync(request.Query);


        return new ApiResponse<List<UserDto>>
        {
            Success = true,
            Message = "Users fetched successfully",
            Data = users.Select(user => new UserDto
            {
                Email = user.Email!,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                RegiterAt = user.RegiterAt,
                SecondLastName = user.SecondLastName,
                UserName = user.UserName!
            }).ToList()
        };
    }
}
