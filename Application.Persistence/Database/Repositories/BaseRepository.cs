using Application.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.Database.Repositories;

public abstract class BaseRepository<TResult> where TResult : class
{
    private readonly ApplicationContext _dbContext;

    // consider using interface
    protected BaseRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TResult> Execute(params IQuery<TResult>[] queries)
    {
        var q = ApplyQueries(queries);

        return await q.SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<TResult>> ExecuteList(params IQuery<TResult>[] queries)
    {
        var q = ApplyQueries(queries);

        return await q.ToListAsync();
    }

    private IQueryable<TResult> ApplyQueries(params IQuery<TResult>[] queries)
    {
        var q = _dbContext
            .Set<TResult>()
            .AsQueryable();

        foreach (var query in queries)
        {
            q = q.Apply(query);
        }

        return q;
    }

    public async Task Add(TResult entity)
    {
        await _dbContext.Set<TResult>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}