using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query; 
using System.Linq.Expressions; 

namespace Core.Persistence.Repositories.ReadRepositories;

public interface IReadRepository<T,TIdType> : IQuery<T> where T : Entity<TIdType>
{
    T Get(Expression<Func<T, bool>> predicate);

    IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true);

    IPaginate<T> GetListByDynamic(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true);
}
