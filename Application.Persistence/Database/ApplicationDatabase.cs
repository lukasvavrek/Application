using Application.Domain.Models;
using Application.Domain.Repositories;

namespace Application.Persistence.Database;

public class ApplicationDatabase : IDatabase
{
    private readonly ApplicationContext _context;

    public ApplicationDatabase(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<ApplicationDao> Applications => _context.Set<ApplicationDao>();

    public async Task AddAsync<T>(T entity) where T : ApplicationDao
    {
        await _context.Set<T>().AddAsync(entity);
    }
    
    public Task<int> CommitAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}