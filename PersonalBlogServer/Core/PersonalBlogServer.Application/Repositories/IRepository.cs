using System.Linq.Expressions;

namespace PersonalBlogServer.Application.Repositories;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
}
