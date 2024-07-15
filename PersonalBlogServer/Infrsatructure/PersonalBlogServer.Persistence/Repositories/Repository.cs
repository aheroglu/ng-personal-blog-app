using Microsoft.EntityFrameworkCore;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Persistence.Contexts;
using System.Linq.Expressions;

namespace PersonalBlogServer.Persistence.Repositories;

public sealed class Repository<T>(
    AppDbContext context) : IRepository<T> where T : class
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        var values = await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
        if (values is null) throw new InvalidOperationException("Not found!");
        return values;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }
}
