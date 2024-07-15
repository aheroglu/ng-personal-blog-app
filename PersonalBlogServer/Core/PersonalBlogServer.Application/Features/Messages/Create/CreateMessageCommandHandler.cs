using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Messages.Create;

internal sealed class CreateMessageCommandHandler(
    IRepository<Message> repository) : IRequestHandler<CreateMessageCommand>
{
    public async Task Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new Message
        {
            Name = request.Name,
            Email = request.Email,
            Content = request.Content,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }, cancellationToken);
    }
}
