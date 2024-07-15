using MediatR;

namespace PersonalBlogServer.Application.Features.Messages.GetAll;

public sealed class GetAllMessagesQuery : IRequest<List<GetAllMessagesQueryResult>>;
