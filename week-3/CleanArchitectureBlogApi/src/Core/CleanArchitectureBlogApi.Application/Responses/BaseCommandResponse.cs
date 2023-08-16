namespace CleanArchtectureBlogApi.Application.Responses;

public class BaseCommandResponse
{
    public BaseCommandResponse(string message)
    {
        Success = false;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}
