using Application.Domain.Models;
using Application.Domain.Operations.Search;

namespace Application.Domain.Queries;

public class SearchApplicationQuery : IQuery<ApplicationDao>
{
    private readonly SearchApplicationsRequest _request;

    public SearchApplicationQuery(SearchApplicationsRequest request)
    {
        _request = request;
    }
    
    public IQueryable<ApplicationDao> Apply(IQueryable<ApplicationDao> query)
    {
        if (!string.IsNullOrWhiteSpace(_request.TitleStartsWith))
        {
            query = query.Where(application => application.Title.StartsWith(_request.TitleStartsWith));
        }

        return query;
    }
}