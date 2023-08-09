using BlogWebApp.Application.CustomExceptions;
using BlogWebApp.Application.Services;
using BlogWebApp.Contracts.Comment;
using BlogWebApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApp.WebApi.Controllers;

[ApiController]
[Route("posts/{postId}/comments")]
public class ComentsController : ControllerBase
{
    private readonly CommentsService _commentsService;

    public ComentsController(CommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet]
    public IActionResult GetComments(int postId)
    {
        try
        {
            var comments = _commentsService.GetAllCommentsOfPost(postId);

            var response = new List<CommentResponse>();

            foreach (Comment comment in comments)
            {
                response.Add(new CommentResponse(comment.Id, comment.Text));
            }

            return Ok(response);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpPost]
    public IActionResult CreateComment(int postId, CommentRequest request)
    {
        try
        {
            var commentRequest = new Comment() { PostId = postId, Text = request.Text };
            var createdComment = _commentsService.AddNewComment(commentRequest);

            var response = new CommentResponse(createdComment.Id, createdComment.Text);
            return CreatedAtAction(actionName: nameof(GetComment), routeValues: createdComment.Id, value: response);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpGet("{commentId:int}")]
    public IActionResult GetComment(int postId, int commentId)
    {
        try
        {
            var comment = _commentsService.GetComment(commentId);

            var response = new CommentResponse(comment.Id, comment.Text);
            return Ok(response);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpPut("{commentId:int}")]
    public IActionResult UpdateComment(int postId, int commentId, CommentRequest request)
    {
        try
        {
            var commentRequest = new Comment() { Text = request.Text };
            var updatedComment = _commentsService.UpdateComment(commentId, commentRequest);

            var response = new CommentResponse(updatedComment.Id, updatedComment.Text);
            return Ok(response);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpDelete("{commentId:int}")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        try
        {
            _commentsService.DeleteComment(commentId);
            return NoContent();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }
}
