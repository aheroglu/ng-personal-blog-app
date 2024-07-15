using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Abouts.GetAll;

internal sealed class GetAllAboutQueryHandler(
    IRepository<About> repository) : IRequestHandler<GetAllAboutQuery, List<GetAllAboutQueryResult>>
{
    public async Task<List<GetAllAboutQueryResult>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values
            .Select(p => new GetAllAboutQueryResult(
                p.Id,
                p.Content,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();
    }
}
