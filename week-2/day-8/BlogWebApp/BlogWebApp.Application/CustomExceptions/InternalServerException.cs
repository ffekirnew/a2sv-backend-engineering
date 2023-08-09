namespace BlogWebApp.Application.CustomExceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string message)
        : base(message) { }

    public InternalServerException(string message, Exception innerException)
        : base(message, innerException) { }

    public InternalServerException()
        : base("Something went wrong. Please try again.") { }
}
