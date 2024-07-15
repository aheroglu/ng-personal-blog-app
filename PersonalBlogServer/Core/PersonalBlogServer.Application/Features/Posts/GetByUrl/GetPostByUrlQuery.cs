using MediatR;

namespace PersonalBlogServer.Application.Features.Posts.GetByUrl;

public sealed class GetPostByUrlQuery : IRequest<GetPostByUrlQueryResult>
{
    public GetPostByUrlQuery(string postUrl)
    {
        PostUrl = postUrl;
    }

    public string PostUrl { get; set; } = string.Empty;
}
