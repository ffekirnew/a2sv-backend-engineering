using BlogWebApp.Application.CustomExceptions;
using BlogWebApp.Application.Interfaces;
using BlogWebApp.Domain.Entities;
using BlogWebApp.Infrastructure.Data;

namespace BlogWebApp.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context) => _context = context;

    public Comment AddNewComment(Comment comment)
    {
        try
        {
            _context.Add(comment);
            _context.SaveChanges();

            return comment;
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public Comment GetCommentById(int commentId)
    {
        try
        {
            Comment? comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment != null)
                return comment;
            else
                throw new EntityNotFoundException("Comment", commentId);
        }
        catch (EntityNotFoundException)
        {
            throw;
        }
        catch
        {
            throw new InternalServerException();
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
        catch (EntityNotFoundException)
        {
            throw new EntityNotFoundException("Comment", commentId);
        }
        catch
        {
            throw new InternalServerException();
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
        catch (EntityNotFoundException)
        {
            throw new EntityNotFoundException("Comment", commentId);
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public List<Comment> GetAllCommentsOfPost(int postId)
    {
        try
        {
            List<Comment> postComments = new();
            var comments = _context.Comments.Where(c => c.PostId == postId).ToList();

            foreach (Comment comment in comments)
            {
                postComments.Add(comment);
            }

            return postComments;
        }
        catch
        {
            throw new InternalServerException();
        }
    }
}
