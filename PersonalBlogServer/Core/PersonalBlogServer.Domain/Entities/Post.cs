using PersonalBlogServer.Domain.Entities.Abstractions;

namespace PersonalBlogServer.Domain.Entities;

public sealed class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string PostUrl { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}