using Application.Domain.Models;
using Application.Domain.Queries;
using Application.Domain.Repositories;

namespace Application.Domain.Operations.Search;

internal class SearchApplicationsOperation 
    : IOperation<SearchApplicationsRequest, SearchApplicationResponse>
{
    private readonly IDatabase _database;

    public SearchApplicationsOperation(IDatabase database)
    {
        _database = database;
    }
    
    public async Task<SearchApplicationResponse> OnOperate(SearchApplicationsRequest request)
    {
        var query = _database.Applications(TrackingOption.WithoutTracking)
            .Apply(new SearchApplicationQuery(request))
            .Apply(new PaginationQuery<ApplicationDao>(request));

        var response = await _database.ToListAsync(query);
        
        return SearchApplicationResponse.FromData(response);
    }
}