namespace CleanArchtectureBlogApi.Application.Exceptions;


public class NotFoundException : Exception
{

    public NotFoundException(string entityName, object id) : base($"Entity \"{entityName}\" ({id}) was not found.")
    {
    }
}
