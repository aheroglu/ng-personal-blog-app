using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Abouts.Update;

internal sealed class UpdateAboutCommandHandler(
    IRepository<About> repository) : IRequestHandler<UpdateAboutCommand>
{
    public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);
        values.Content = request.Content;
        values.UpdatedAt = DateTime.Now;
        await repository.UpdateAsync(values);
    }
}
