using BlogApp.Application;
using BlogApp.Contracts.Comment;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Presentation.Controllers;

[ApiController]
[Route("posts/{postId}/comments")]
public class CommentsController : ControllerBase
{
    private readonly CommentApplication _commentUseCase;

    public CommentsController(CommentApplication commentUseCase)
    {
        _commentUseCase = commentUseCase;
    }

    [HttpPost]
    public IActionResult CreateComment(int postId, CommentRequest request)
    {
        Comment newComment = new Comment();
        newComment.PostId = postId;
        newComment.Text = request.Text;

        Comment createdComment = _commentUseCase.AddNewComment(newComment);

        CommentResponse response = new CommentResponse(
            createdComment.Id,
            createdComment.PostId,
            createdComment.Text
        );

        return CreatedAtAction(
            actionName: nameof(GetComment),
            routeValues: new { postId = postId, id = response.commentId },
            value: response
        );
    }

    [HttpGet("{id:int}")]
    public IActionResult GetComment(int postId, int id)
    {
        try
        {
            Comment comment = _commentUseCase.GetComment(id);

            if (comment == null || comment.PostId != postId)
            {
                return NotFound();
            }

            CommentResponse response = new CommentResponse(
                comment.Id,
                comment.PostId,
                comment.Text
            );

            return Ok(response);
        }
        catch (Exception ex)
        {
            return NotFound(ex.ToString());
        }
    }

    [HttpGet]
    public IActionResult GetComments(int postId)
    {
        List<Comment> comments = _commentUseCase.GetAllCommentsOfPost(postId);
        List<CommentResponse> response = new List<CommentResponse>();

        foreach (Comment comment in comments)
        {
            response.Add(new CommentResponse(comment.Id, comment.PostId, comment.Text));
        }

        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteComment(int postId, int id)
    {
        Comment deletedComment = _commentUseCase.DeleteComment(id);

        if (deletedComment == null || deletedComment.PostId != postId)
        {
            return NotFound();
        }

        CommentResponse response = new CommentResponse(
            deletedComment.Id,
            deletedComment.PostId,
            deletedComment.Text
        );

        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateComment(int postId, int id, CommentRequest request)
    {
        Comment updatedComment = new Comment();
        updatedComment.Text = request.Text;

        Comment result = _commentUseCase.UpdateComment(id, updatedComment);

        if (result == null || result.PostId != postId)
        {
            return NotFound();
        }

        CommentResponse response = new CommentResponse(
            updatedComment.Id,
            updatedComment.PostId,
            updatedComment.Text
        );

        return Ok(response);
    }
}
