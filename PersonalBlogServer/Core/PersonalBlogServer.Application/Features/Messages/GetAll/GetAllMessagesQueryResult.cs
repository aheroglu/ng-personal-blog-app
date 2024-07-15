namespace PersonalBlogServer.Application.Features.Messages.GetAll;

public sealed record GetAllMessagesQueryResult(
    int Id,
    string Name,
    string Email,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
