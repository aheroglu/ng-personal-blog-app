using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.GetAll;

internal sealed class GetAllPostsQueryHandler(
    IRepository<Post> repository) : IRequestHandler<GetAllPostsQuery, List<GetAllPostsQueryResult>>
{
    public async Task<List<GetAllPostsQueryResult>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync(cancellationToken);
        return values
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new GetAllPostsQueryResult(
                p.Id,
                p.Title,
                p.PostUrl,
                p.Image,
                p.Description,
                p.Content,
                p.CreatedAt,
                p.UpdatedAt))
            .ToList();
    }
}
