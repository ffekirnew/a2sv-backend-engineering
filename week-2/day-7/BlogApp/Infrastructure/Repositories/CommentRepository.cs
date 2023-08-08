using BlogApp.Application.Interfaces;
using BlogApp.Data;
using BlogApp.Domain.Entities;

namespace BlogApp.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context) => _context = context;

    public Comment AddNewComment(Comment comment)
    {
        _context.Add(comment);
        _context.SaveChanges();

        return comment;
    }

    public Comment GetCommentById(int commentId)
    {
        Comment? comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

        if (comment != null)
        {
            return comment;
        }
        else
        {
            throw new Exception("Comment not found.");
        }
    }

    public Comment UpdateComment(int commentId, Comment comment)
    {
        try
        {
            var existingComment = GetCommentById(commentId);
            existingComment.Text = comment.Text;

            _context.SaveChanges();
            return existingComment;
        }
        catch
        {
            throw;
        }
    }

    public Comment DeleteComment(int commentId)
    {
        try
        {
            Comment comment = GetCommentById(commentId);
            _context.Remove(comment);
            _context.SaveChanges();
            return comment;
        }
        catch 
        {
            throw;
        }
    }

    public List<Comment> GetAllCommentsOfPost(int postId)
    {
        List<Comment> postComments = new();
        var comments = _context.Comments.Where(c => c.PostId == postId).ToList();

        foreach (Comment comment in comments)
        {
            postComments.Add(comment);
        }

        return postComments;
    }
}
