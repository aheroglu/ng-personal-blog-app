using MediatR;

namespace PersonalBlogServer.Application.Features.Socials.GetById;

public sealed class GetSocialByIdQuery : IRequest<GetSocialByIdQueryResult>
{
    public int Id { get; set; }

    public GetSocialByIdQuery(int id)
    {
        Id = id;
    }
}
