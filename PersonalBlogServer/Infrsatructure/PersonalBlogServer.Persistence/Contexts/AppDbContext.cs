using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalBlogServer.Domain.Entities;

namespace PersonalBlogServer.Persistence.Contexts;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<IdentityUserLogin<int>>();
        builder.Ignore<IdentityRoleClaim<int>>();
        builder.Ignore<IdentityUserClaim<int>>();
        builder.Ignore<IdentityUserToken<int>>();
        builder.Ignore<IdentityUserRole<int>>();
        builder.Ignore<IdentityRole<int>>();
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Social> Socials { get; set; }
}
