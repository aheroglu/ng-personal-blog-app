using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.GetByUrl;

internal sealed class GetPostByUrlQueryHandler(
    IRepository<Post> repository) : IRequestHandler<GetPostByUrlQuery, GetPostByUrlQueryResult>
{
    public async Task<GetPostByUrlQueryResult> Handle(GetPostByUrlQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.PostUrl == request.PostUrl, cancellationToken);
        return new GetPostByUrlQueryResult(
            values.Id,
            values.Title,
            values.PostUrl,
            values.Image,
            values.Description,
            values.Content,
            values.CreatedAt,
            values.UpdatedAt);
    }
}
