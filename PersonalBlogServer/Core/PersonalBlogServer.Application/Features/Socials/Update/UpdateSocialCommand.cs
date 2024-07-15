using MediatR;

namespace PersonalBlogServer.Application.Features.Socials.Update;

public sealed record UpdateSocialCommand(
    int Id,
    string Icon,
    string Url) : IRequest;
