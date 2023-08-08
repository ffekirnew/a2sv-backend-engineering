using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Services;

class CommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context) => _context = context;

    public Comment AddNewComment(Comment comment)
    {
        _context.Add(comment);

        return comment;
    }

    public List<Comment> GetAllComments()
    {
        List<Comment> comments = new();

        foreach (Comment comment in _context.Comments)
        {
            comments.Add(comment);
        }

        return comments;
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
            throw new ArgumentException("Comment not found.");
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
            return comment;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
