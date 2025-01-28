using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IQuerySqlDB<T> where T : class
    {
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filterExpression, bool tracking = true);

        Task<T> FirstOrDefaultIncludeAsync(string navigationPropertyPath, Expression<Func<T, bool>> filter, bool tracking = true);

        Task<List<T>> WhereAsync(Expression<Func<T, bool>> filterExpression, bool tracking = true);

        Task<List<T>> WhereIncludeAsync(string navigationPropertyPath, Expression<Func<T, bool>> filter, bool tracking = true);

        Task<List<T>> GetPaginatedListAsync(Expression<Func<T, bool>> filterExpression, int page, int pageSize, bool tracking = true);

        Task<List<T>> GetPaginatedListIncludeAsync(string navigationPropertyPath, Expression<Func<T, bool>> filterExpression, int page, int pageSize, bool tracking = true);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

        Task<int> CountAsync(Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default);

        IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
    }
}
