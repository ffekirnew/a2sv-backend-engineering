namespace BlogApp.Contracts.Post;

record PostResponse(int Id, string Title, string Content, DateTime CreatedAt);
