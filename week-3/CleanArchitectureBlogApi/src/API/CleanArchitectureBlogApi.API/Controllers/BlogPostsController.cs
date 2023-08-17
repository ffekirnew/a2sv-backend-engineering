using System.ComponentModel.DataAnnotations;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlogApi.API.Controllers;

[ApiController]
[Route("blogposts")]
public class BlogPostsController : ControllerBase
{
    private IMediator _mediator;

    public BlogPostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries
    [HttpGet]
    public async Task<ActionResult<List<BlogPostListDto>>> Get()
    {
        var result = await _mediator.Send(new GetBlogPostListRequest());
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogPostDto>> Get(int id)
    {
        var result = await _mediator.Send(new GetBlogPostDetailRequest { Id = id });
        return Ok(result);
    }
    #endregion

    #region Commands
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] BlogPostCreateDto request)
    {
        var result = await _mediator.Send(
            new CreateBlogPostCommand { BlogPostCreateDto = request }
        );
        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] BlogPostUpdateDto request)
    {
        await _mediator.Send(new UpdateBlogPostCommand { Id = id, BlogPostUpdateDto = request });
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteBlogPostCommand { Id = id });
        return NoContent();
    }
    #endregion
}
