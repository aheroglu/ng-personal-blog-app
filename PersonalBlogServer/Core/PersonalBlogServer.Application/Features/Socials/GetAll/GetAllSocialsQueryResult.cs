namespace PersonalBlogServer.Application.Features.Socials.GetAll;

public sealed record GetAllSocialsQueryResult(
    int Id,
    string Icon,
    string Url,
    DateTime CreatedAt,
    DateTime UpdatedAt);
