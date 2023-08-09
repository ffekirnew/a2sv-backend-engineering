using BlogWebApp.Application;
using BlogWebApp.Application.CustomExceptions;
using BlogWebApp.Contracts.Post;
using BlogWebApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApp.WebApi.Controllers;

[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly PostsApplication _postsApplication;

    public PostsController(PostsApplication postsApplication)
    {
        _postsApplication = postsApplication;
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        try
        {
            var posts = _postsApplication.GetAllPosts();
            List<PostResponse> response = new();

            foreach (Post post in posts)
            {
                response.Add(new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt));
            }
            return Ok(response);
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpPost]
    public IActionResult CreatePost(PostRequest request)
    {
        try
        {
            // Make application call
            Post post = _postsApplication.AddNewPost(
                new Post() { Title = request.Title, Content = request.Content }
            );
            // Reformat in in the response format
            var response = new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt);
            // Return the response or handle errors
            return CreatedAtAction(
                actionName: nameof(GetPosts),
                routeValues: post.Id,
                value: response
            );
        }
        catch (InternalServerException)
        {
            return StatusCode(500, "Something went wrong. Please try again.");
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetPost(int id)
    {
        try
        {
            var post = _postsApplication.GetPost(id);
            var response = new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt);
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

    [HttpPut("{id:int}")]
    public IActionResult UpdatePost(int id, PostRequest request)
    {
        try
        {
            var postRequest = new Post() { Title = request.Title, Content = request.Content };
            var updatedPost = _postsApplication.UpdatePost(id, postRequest);
            var response = new PostResponse(
                updatedPost.Id,
                updatedPost.Title,
                updatedPost.Content,
                updatedPost.CreatedAt
            );

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

    [HttpDelete("{id:int}")]
    public IActionResult DeletePost(int id)
    {
        try
        {
            _postsApplication.DeletePost(id);

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
