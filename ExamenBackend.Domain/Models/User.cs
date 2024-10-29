
using Microsoft.AspNetCore.Identity;

namespace ExamenBackend.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string SecondLastName { get;set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime RegiterAt { get; set; }
}
