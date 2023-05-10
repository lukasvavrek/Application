using Application.Domain.Operations;

namespace Application.Domain.Queries;

public class PaginationQuery<TResult> : IQuery<TResult>
{
    private readonly IPaginationRequest _request;

    public PaginationQuery(IPaginationRequest request)
    {
        _request = request;
    }
    
    public IQueryable<TResult> Apply(IQueryable<TResult> query)
    {
        query = query
            .Skip(_request.Skip)
            .Take(_request.Take);

        return query;
    }
}