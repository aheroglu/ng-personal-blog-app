using MediatR;

namespace PersonalBlogServer.Application.Features.Socials.GetAll;

public sealed class GetAllSocialsQuery : IRequest<List<GetAllSocialsQueryResult>>;
