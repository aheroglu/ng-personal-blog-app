namespace PersonalBlogServer.Application.Features.Posts.GetById;

public sealed record GetPostByIdQueryResult(
    int Id,
    string Title,
    string PostUrl,
    string Image,
    string Description,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt);
