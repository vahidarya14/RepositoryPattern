namespace Repo.Framework
{
    public interface IRepository<T>
    {
        List<T> GetItems();
        ValueTask<T> InsertAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<T> UpdateAsync(T model, CancellationToken cancellationToken = default);
        ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken = default);
    }



}
