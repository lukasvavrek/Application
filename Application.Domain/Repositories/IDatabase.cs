using Application.Domain.Models;

namespace Application.Domain.Repositories;

public interface IDatabase
{
    public IQueryable<ApplicationDao> Applications { get; }

    public Task AddAsync<T>(T entity) where T : ApplicationDao;

    public Task<int> CommitAsync(CancellationToken cancellationToken = new());

    public Task<IEnumerable<T>> ToListAsync<T>(IQueryable<T> entity, CancellationToken cancellationToken = new ()) where T : ApplicationDao;
}