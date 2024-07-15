using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Socials.Delete;

internal sealed class DeleteSocialCommandHandler(
    IRepository<Social> repository) : IRequestHandler<DeleteSocialCommand>
{
    public async Task Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        await repository.DeleteAsync(values);
    }
}
