using PersonalBlogServer.Domain.Entities.Abstractions;

namespace PersonalBlogServer.Domain.Entities;

public sealed class Social : BaseEntity
{
    public string Icon { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
