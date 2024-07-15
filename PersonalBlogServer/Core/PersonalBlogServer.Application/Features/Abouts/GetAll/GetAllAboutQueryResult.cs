namespace PersonalBlogServer.Application.Features.Abouts.GetAll;

public sealed record GetAllAboutQueryResult(
    int Id,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
