using ExamenBackend.Domain.Models;
using ExamenBackend.Domain.Repositories;
using ExamenBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamenBackend.Infrastructure.Repositories;
internal class UserRepository(GlobalDbContext context) : IUserRepository
{
    public async Task<List<User>> GetUsersAsync(string query)
    {
        var users = await context.Users
            .Where(user => user.FirstName.Contains(query))
            .AsNoTracking().ToListAsync();

        return users;
    }
}
