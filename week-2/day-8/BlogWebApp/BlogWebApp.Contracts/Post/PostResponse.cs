namespace BlogWebApp.Contracts.Post;

public record PostResponse(int Id, string Title, string Content, DateTime CreatedAt);
