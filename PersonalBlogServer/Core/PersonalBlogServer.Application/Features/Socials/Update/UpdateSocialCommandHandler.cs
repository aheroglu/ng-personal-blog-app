using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Socials.Update;

internal sealed class UpdateSocialCommandHandler(
    IRepository<Social> repository) : IRequestHandler<UpdateSocialCommand>
{
    public async Task Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        values.Icon = request.Icon;
        values.Url = request.Url;
        values.UpdatedAt = DateTime.Now;
        await repository.UpdateAsync(values);
    }
}
