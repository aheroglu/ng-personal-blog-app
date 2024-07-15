using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Socials.Create;

internal sealed class CreateSocialCommandHandler(
    IRepository<Social> repository) : IRequestHandler<CreateSocialCommand>
{
    public async Task Handle(CreateSocialCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new Social
        {
            Icon = request.Icon,
            Url = request.Url,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }, cancellationToken);
    }
}
