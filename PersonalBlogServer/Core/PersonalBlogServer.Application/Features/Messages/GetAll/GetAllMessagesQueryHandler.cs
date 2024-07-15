using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Messages.GetAll;

internal sealed class GetAllMessagesQueryHandler(
    IRepository<Message> repository) : IRequestHandler<GetAllMessagesQuery, List<GetAllMessagesQueryResult>>
{
    public async Task<List<GetAllMessagesQueryResult>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new GetAllMessagesQueryResult(
                p.Id,
                p.Name,
                p.Email,
                p.Content,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();
    }
}
