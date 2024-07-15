using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Messages.GetById;

internal sealed class GetMessageByIdQueryHandler(
   IRepository<Message> repository) : IRequestHandler<GetMessageByIdQuery, GetMessageByIdQueryResult>
{
    public async Task<GetMessageByIdQueryResult> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        return new GetMessageByIdQueryResult(
            values.Id,
            values.Name,
            values.Email,
            values.Content,
            values.CreatedAt,
            values.UpdatedAt);
    }
}