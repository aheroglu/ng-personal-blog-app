using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Features.Posts.Create;
using PersonalBlogServer.Application.Features.Posts.Delete;
using PersonalBlogServer.Application.Features.Posts.GetAll;
using PersonalBlogServer.Application.Features.Posts.GetById;
using PersonalBlogServer.Application.Features.Posts.GetByUrl;
using PersonalBlogServer.Application.Features.Posts.Update;
using PersonalBlogServer.WebAPI.Abstractions;

namespace PersonalBlogServer.WebAPI.Controllers;

public class PostsController : ApiController
{
    public PostsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var values = await mediator.Send(new GetAllPostsQuery(), cancellationToken);
        return StatusCode(200, values);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var values = await mediator.Send(new GetPostByIdQuery(id), cancellationToken);
        return StatusCode(200, values);
    }

    [HttpGet]
    public async Task<IActionResult> GetByUrl(string postUrl, CancellationToken cancellationToken)
    {
        var values = await mediator.Send(new GetPostByUrlQuery(postUrl), cancellationToken);
        return StatusCode(200, values);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatePostCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return StatusCode(200, new { Message = "Post created successfully" });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeletePostCommand(id), cancellationToken);
        return StatusCode(200, new { Message = "Post deleted successfully" });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdatePostCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return StatusCode(200, new { Message = "Post updated successfully" });
    }
}
