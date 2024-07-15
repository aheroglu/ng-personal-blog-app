using MediatR;

namespace PersonalBlogServer.Application.Features.Abouts.Update;

public sealed record UpdateAboutCommand(
    int Id,
    string Content) : IRequest;
