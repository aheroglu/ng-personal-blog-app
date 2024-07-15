using MediatR;

namespace PersonalBlogServer.Application.Features.Posts.Delete;

public sealed record DeletePostCommand(
    int Id) : IRequest;
