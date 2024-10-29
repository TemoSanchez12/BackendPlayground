using ExamenBackend.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenBackend.Infrastructure.Persistence;

internal class GlobalDbContext(DbContextOptions<GlobalDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<User> Users { get; set; }
}
