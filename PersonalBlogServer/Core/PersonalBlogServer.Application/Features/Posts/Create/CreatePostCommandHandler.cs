using GenericFileService.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Posts.Create;

internal sealed class CreatePostCommandHandler(
    IRepository<Post> repository) : IRequestHandler<CreatePostCommand>
{
    public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        string image = FileService
            .FileSaveToServer(request.Image, "wwwroot/img/posts/");

        await repository.CreateAsync(new Post
        {
            Title = request.Title,
            PostUrl = request.PostUrl,
            Image = image,
            Description = request.Description,
            Content = request.Content,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }, cancellationToken);
    }
}
