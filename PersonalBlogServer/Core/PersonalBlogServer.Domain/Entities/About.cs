using PersonalBlogServer.Domain.Entities.Abstractions;

namespace PersonalBlogServer.Domain.Entities;

public sealed class About : BaseEntity
{
    public string Content { get; set; } = string.Empty;
}
