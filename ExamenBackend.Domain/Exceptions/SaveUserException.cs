namespace ExamenBackend.Domain.Exceptions;

public class SaveUserException(string userIdentifier) : Exception($"Something went wrong while creating user {userIdentifier}")
{
}
