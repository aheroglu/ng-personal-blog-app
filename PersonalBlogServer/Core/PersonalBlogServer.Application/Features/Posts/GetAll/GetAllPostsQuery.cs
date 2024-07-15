using MediatR;

namespace PersonalBlogServer.Application.Features.Posts.GetAll;

public sealed class GetAllPostsQuery : IRequest<List<GetAllPostsQueryResult>>;
