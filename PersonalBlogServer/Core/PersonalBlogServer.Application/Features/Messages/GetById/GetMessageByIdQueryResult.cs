namespace PersonalBlogServer.Application.Features.Messages.GetById;

public sealed record GetMessageByIdQueryResult(
    int Id,
    string Name,
    string Email,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
