namespace BlogApp.Contracts.Comment;

public record CommentResponse(int commentId, int postId, string Text);
