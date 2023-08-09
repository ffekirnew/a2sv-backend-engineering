namespace BlogWebApp.Application.CustomExceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, int entityId)
        : base($"{entityName} with id {entityId} is not found.") { }

    public EntityNotFoundException(string message)
        : base(message) { }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}
