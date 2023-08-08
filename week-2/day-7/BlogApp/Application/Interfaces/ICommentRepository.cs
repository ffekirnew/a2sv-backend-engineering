using BlogApp.Domain.Entities;

namespace BlogApp.Application.Interfaces;

public interface ICommentRepository
{
    Comment AddNewComment(Comment comment);
    Comment GetCommentById(int commentId);
    Comment UpdateComment(int commentId, Comment comment);
    Comment DeleteComment(int commentId);
    List<Comment> GetAllCommentsOfPost(int postId);
}
