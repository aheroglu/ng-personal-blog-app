using MediatR;
using Microsoft.AspNetCore.Http;

namespace PersonalBlogServer.Application.Features.Posts.Update;

public sealed record UpdatePostCommand(
    int Id,
    string Title,
    string PostUrl,
    IFormFile Image,
    string Description,
    string Content) : IRequest;
