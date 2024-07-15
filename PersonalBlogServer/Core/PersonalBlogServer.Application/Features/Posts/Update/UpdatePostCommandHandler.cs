using GenericFileService.Files;
using MediatR;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.Update;

internal sealed class UpdatePostCommandHandler(
    IRepository<Post> repository) : IRequestHandler<UpdatePostCommand>
{
    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await repository.GetByAsync(p => p.Id == request.Id, cancellationToken);

        // Delete older image
        FileService
           .FileDeleteToServer("wwwroot/img/posts/" + post.Image);

        // Save new image
        string image = FileService
            .FileSaveToServer(request.Image, "wwwroot/img/posts/");

        post.Title = request.Title;
        post.PostUrl = request.PostUrl;
        post.Image = image;
        post.Description = request.Description;
        post.Content = request.Content;
        post.UpdatedAt = DateTime.Now;
        await repository.UpdateAsync(post);
    }
}
