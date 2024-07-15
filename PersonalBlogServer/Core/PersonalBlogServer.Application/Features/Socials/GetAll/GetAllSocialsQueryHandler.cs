using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Socials.GetAll;

internal sealed class GetAllSocialsQueryHandler(
    IRepository<Social> repository) : IRequestHandler<GetAllSocialsQuery, List<GetAllSocialsQueryResult>>
{
    public async Task<List<GetAllSocialsQueryResult>> Handle(GetAllSocialsQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new GetAllSocialsQueryResult(
                p.Id,
                p.Icon,
                p.Url,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();
    }
}
