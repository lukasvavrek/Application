namespace Application.Domain.Queries;

public static class QueryExtensions
{
    public static IQueryable<TResult> Apply<TResult>(this IQueryable<TResult> query, IQuery<TResult> q)
    {
        return q.Apply(query);
    }
}