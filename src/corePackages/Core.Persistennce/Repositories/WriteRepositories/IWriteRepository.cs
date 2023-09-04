namespace Core.Persistence.Repositories.WriteRepositories;

public interface IWriteRepository<T, TIdType> : IQuery<T> where T : Entity<TIdType>
{
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}
