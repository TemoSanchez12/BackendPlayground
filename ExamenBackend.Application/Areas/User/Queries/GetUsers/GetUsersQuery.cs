using ExamenBackend.Application.Areas.User.Models;
using ExamenBackend.Application.Models;
using MediatR;

namespace ExamenBackend.Application.Areas.User.Queries.GetUsers;

public class GetUsersQuery : IRequest<ApiResponse<List<UserDto>>>
{
    public string Query { get; set; } = string.Empty;
}
