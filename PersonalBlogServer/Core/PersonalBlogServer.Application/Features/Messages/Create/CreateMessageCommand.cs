using MediatR;

namespace PersonalBlogServer.Application.Features.Messages.Create;

public sealed record CreateMessageCommand(
    string Name,
    string Email,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt) : IRequest;
