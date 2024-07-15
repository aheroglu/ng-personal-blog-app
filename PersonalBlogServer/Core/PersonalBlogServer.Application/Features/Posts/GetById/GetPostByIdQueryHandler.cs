using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.GetById;

internal sealed class GetPostByIdQueryHandler(
    IRepository<Post> repository) : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryResult>
{
    public async Task<GetPostByIdQueryResult> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        return new GetPostByIdQueryResult(
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
