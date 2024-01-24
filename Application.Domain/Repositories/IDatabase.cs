using Application.Domain.Models;

namespace Application.Domain.Repositories;

public interface IDatabase
{
    public IQueryable<ApplicationDao> Applications { get; }

    public Task AddAsync<T>(T entity) where T : ApplicationDao;

    public Task<int> CommitAsync(CancellationToken cancellationToken = new());
}