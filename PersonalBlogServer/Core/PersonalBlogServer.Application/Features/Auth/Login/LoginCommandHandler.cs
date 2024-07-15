using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, string>
{
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.UserName == request.UserName, cancellationToken);

        if (user is null) return "User not found!";

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordCorrect) return "Incorrect password!";

        string token = jwtProvider.CreateToken(user);

        return token;
    }
}
