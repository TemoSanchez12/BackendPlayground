namespace ExamenBackend.Application.Areas.User.Models;

internal class UserDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string SecondLastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime RegiterAt { get; set; }
}
