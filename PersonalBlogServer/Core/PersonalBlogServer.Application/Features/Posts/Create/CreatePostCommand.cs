using MediatR;
using Microsoft.AspNetCore.Http;

namespace PersonalBlogServer.Application.Features.Posts.Create;

public sealed record CreatePostCommand(
    string Title,
    string PostUrl,
    IFormFile Image,
    string Description,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt) : IRequest;
