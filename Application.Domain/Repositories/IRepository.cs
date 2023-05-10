using Application.Domain.Queries;

namespace Application.Domain.Repositories;

public interface IRepository<TResult>
{
    Task<TResult> Execute(params IQuery<TResult>[] queries);
    Task<IEnumerable<TResult>> ExecuteList(params IQuery<TResult>[] queries);

    Task Add(TResult entity);
    
    Task SaveChangesAsync();
}