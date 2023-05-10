namespace Application.Domain.Queries;

public interface IQuery<TResult>
{
    IQueryable<TResult> Apply(IQueryable<TResult> query);
}