namespace PersonalBlogServer.Application.Features.Posts.GetByUrl;

public sealed record GetPostByUrlQueryResult(
    int Id,
    string Title,
    string PostUrl,
    string Image,
    string Description,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
