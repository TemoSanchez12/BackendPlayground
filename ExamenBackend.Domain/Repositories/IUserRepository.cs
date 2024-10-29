using ExamenBackend.Domain.Models;

namespace ExamenBackend.Domain.Repositories;
public interface IUserRepository
{
    public Task<List<User>> GetUsersAsync(string query);
}
