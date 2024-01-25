using Application.Domain.Models;
using Application.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.Database;

public class ApplicationDatabase : IDatabase
{
    private readonly ApplicationContext _context;

    public ApplicationDatabase(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<ApplicationDao> Applications(TrackingOption tracking)
    {
        return tracking == TrackingOption.WithTracking ?
            _context.Set<ApplicationDao>().AsTracking() : 
            _context.Set<ApplicationDao>().AsNoTracking();
    }

    public async Task AddAsync<T>(T entity) where T : ApplicationDao
    {
        await _context.Set<T>().AddAsync(entity);
    }
    
    public Task<int> CommitAsync(CancellationToken cancellationToken = new())
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> ToListAsync<T>(IQueryable<T> entity, CancellationToken cancellationToken = new()) where T : ApplicationDao
    {
        return await entity.ToListAsync(cancellationToken);
    }
}