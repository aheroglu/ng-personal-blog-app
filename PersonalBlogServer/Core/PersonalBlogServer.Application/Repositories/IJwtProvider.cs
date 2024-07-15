using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Application.Repositories;

public interface IJwtProvider
{
    string CreateToken(AppUser user);
}
