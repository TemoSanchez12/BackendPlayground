namespace ExamenBackend.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentitifier) : Exception($"Resource {resourceType} with id {resourceIdentitifier} was not found")
{
}
