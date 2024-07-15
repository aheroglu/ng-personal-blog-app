namespace PersonalBlogServer.Application.Features.Posts.GetAll;

public sealed record GetAllPostsQueryResult(
    int Id,
    string Title,
    string PostUrl,
    string Image,
    string Description,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
