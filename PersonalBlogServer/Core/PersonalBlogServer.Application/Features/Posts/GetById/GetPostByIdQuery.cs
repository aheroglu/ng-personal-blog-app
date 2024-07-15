using MediatR;

namespace PersonalBlogServer.Application.Features.Posts.GetById;

public sealed record GetPostByIdQuery : IRequest<GetPostByIdQueryResult>
{
    public int Id { get; set; }

    public GetPostByIdQuery(int id)
    {
        Id = id;
    }
}
