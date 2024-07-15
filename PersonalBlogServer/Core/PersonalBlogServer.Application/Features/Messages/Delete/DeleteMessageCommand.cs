using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Messages.Delete;

public sealed record DeleteMessageCommand(
    int Id) : IRequest;

internal sealed class DeleteMessageCommandHandler(
    IRepository<Message> repository) : IRequestHandler<DeleteMessageCommand>
{
    public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        await repository.DeleteAsync(values);
    }
}
