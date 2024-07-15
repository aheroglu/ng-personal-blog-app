using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Socials.GetById;

internal sealed class GetSocialByIdQueryHandler(
    IRepository<Social> repository) : IRequestHandler<GetSocialByIdQuery, GetSocialByIdQueryResult>
{
    public async Task<GetSocialByIdQueryResult> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        return new GetSocialByIdQueryResult(
            values.Id,
            values.Icon,
            values.Url,
            values.CreatedAt,
            values.UpdatedAt);
    }
}
