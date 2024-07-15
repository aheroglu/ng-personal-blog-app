using MediatR;

namespace PersonalBlogServer.Application.Features.Messages.GetById;

public sealed class GetMessageByIdQuery : IRequest<GetMessageByIdQueryResult>
{
    public int Id { get; set; }

    public GetMessageByIdQuery(int id)
    {
        Id = id;
    }
}
