using System.Linq.Expressions;

namespace Repo.Framework
{
    public interface IRepository<T> where T : class
    {
        List<T> GetItems();
        ValueTask<T> InsertAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<T> UpdateAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken = default);
    }
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<T> GetById(int id, CancellationToken cancellationToken = default);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);      
        void AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        //void Remove(T entity, CancellationToken cancellationToken = default);
        void RemoveRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }


}
