using MediatR;

namespace PersonalBlogServer.Application.Features.Socials.Create;

public sealed record CreateSocialCommand(
    string Icon,
    string Url,
    DateTime CreatedAt,
    DateTime UpdatedAt) : IRequest;
