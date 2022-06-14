using System.Linq.Expressions;

namespace Repo.Framework
{
    public interface IRepository<T>
    {
        List<T> GetItems();
        ValueTask<T> InsertAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<T> UpdateAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken = default);
    }
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }


}
