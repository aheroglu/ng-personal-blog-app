namespace PersonalBlogServer.Application.Features.Socials.GetById;

public sealed record GetSocialByIdQueryResult(
    int Id,
    string Icon,
    string Url,
    DateTime CreatedAt,
    DateTime UpdatedAt);
