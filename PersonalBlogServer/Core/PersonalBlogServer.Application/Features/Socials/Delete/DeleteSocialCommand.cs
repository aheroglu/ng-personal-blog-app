using MediatR;

namespace PersonalBlogServer.Application.Features.Socials.Delete;

public sealed record DeleteSocialCommand(
    int Id) : IRequest;
