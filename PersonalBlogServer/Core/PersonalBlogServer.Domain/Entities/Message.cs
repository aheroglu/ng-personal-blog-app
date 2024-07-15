using PersonalBlogServer.Domain.Entities.Abstractions;

namespace PersonalBlogServer.Domain.Entities;

public sealed class Message : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
