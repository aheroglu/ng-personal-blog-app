using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.Delete;

internal sealed class DeletPostCommandHandler(
    IRepository<Post> repository) : IRequestHandler<DeletePostCommand>
{
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        await repository.DeleteAsync(values);
    }
}
