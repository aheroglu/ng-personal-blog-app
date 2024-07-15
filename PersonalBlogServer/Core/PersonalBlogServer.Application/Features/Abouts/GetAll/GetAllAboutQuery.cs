using MediatR;

namespace PersonalBlogServer.Application.Features.Abouts.GetAll;

public sealed class GetAllAboutQuery : IRequest<List<GetAllAboutQueryResult>>;
