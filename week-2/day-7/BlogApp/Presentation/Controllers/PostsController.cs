using BlogApp.Application;
using BlogApp.Contracts.Post;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostApplication _postUseCase;

    public PostsController(PostApplication postUseCase)
    {
        _postUseCase = postUseCase;
    }

    [HttpPost]
    public IActionResult CreatePost(PostRequest request)
    {
        // Convert it to a post
        Post newPost = new();
        newPost.Title = request.Title;
        newPost.Content = request.Content;

        // make the call to the use case
        var createdPost = _postUseCase.AddNewPost(newPost);
        PostResponse response = new PostResponse(
            createdPost.Id,
            createdPost.Title,
            createdPost.Content,
            createdPost.CreatedAt
        );

        // Return it
        return CreatedAtAction(
            actionName: nameof(GetPosts),
            routeValues: new { id = response.Id },
            value: response
        );
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        List<Post> posts = _postUseCase.GetAllPosts();
        List<PostResponse> response = new();

        foreach (Post post in posts)
        {
            response.Add(new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt));
        }
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetPost(int id)
    {
        try
        {
            Post post = _postUseCase.GetPost(id);
            PostResponse response = new PostResponse(
                post.Id,
                post.Title,
                post.Content,
                post.CreatedAt
            );
            return Ok(response);
        }
        catch
        {
            return NotFound("Post is not found.");
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletePost(int id)
    {
        try
        {
            Post post = _postUseCase.DeletePost(id);
            PostResponse response = new PostResponse(
                post.Id,
                post.Title,
                post.Content,
                post.CreatedAt
            );

            return Ok(response);
        }
        catch
        {
            return NotFound("Post is not found.");
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdatePost(int id, PostRequest request)
    {
        try
        {
            Post toBeUpdated = new();
            toBeUpdated.Title = request.Title;
            toBeUpdated.Content = request.Content;

            Post updatedCourse = _postUseCase.UpdatePost(id, toBeUpdated);

            PostResponse resonse = new PostResponse(
                updatedCourse.Id,
                updatedCourse.Title,
                updatedCourse.Content,
                updatedCourse.CreatedAt
            );
            return Ok(updatedCourse);
        }
        catch
        {
            return NotFound("Post is not found.");
        }
    }
}
