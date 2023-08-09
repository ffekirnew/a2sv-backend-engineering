using BlogWebApp.Application.Interfaces;
using BlogWebApp.Domain.Entities;

namespace BlogWebApp.Application;

public class CommentsApplication
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentsApplication(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public List<Comment> GetAllCommentsOfPost(int postId)
    {
        _postRepository.GetPostById(postId);
        return _commentRepository.GetAllCommentsOfPost(postId);
    }

    public Comment GetComment(int commentId)
    {
        return _commentRepository.GetCommentById(commentId);
    }

    public Comment AddNewComment(Comment comment)
    {
        var post = _postRepository.GetPostById(comment.PostId);
        return _commentRepository.AddNewComment(comment);
    }

    public Comment UpdateComment(int commentId, Comment comment)
    {
        return _commentRepository.UpdateComment(commentId, comment);
    }

    public Comment DeleteComment(int commentId)
    {
        return _commentRepository.DeleteComment(commentId);
    }
}
