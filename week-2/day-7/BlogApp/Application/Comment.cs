using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application;

public class CommentApplication
{
    private readonly ICommentRepository _commentRepository;

    public CommentApplication(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public List<Comment> GetAllCommentsOfPost(int postId)
    {
        return _commentRepository.GetAllCommentsOfPost(postId);
    }

    public Comment GetComment(int commentId)
    {
        try
        {
            return _commentRepository.GetCommentById(commentId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Comment AddNewComment(Comment comment)
    {
        try
        {
            return _commentRepository.AddNewComment(comment);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Comment UpdateComment(int commentId, Comment comment)
    {
        try
        {
            return _commentRepository.UpdateComment(commentId, comment);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Comment DeleteComment(int commentId)
    {
        try
        {
            return _commentRepository.DeleteComment(commentId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
