using Application.Domain.Models;
using Application.Domain.Queries;
using Application.Domain.Repositories;

namespace Application.Domain.Operations.Search;

internal class SearchApplicationsOperation : IOperation<SearchApplicationsRequest, SearchApplicationResponse>
{
    private readonly IApplicationRepository _applicationRepository;

    public SearchApplicationsOperation(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task<SearchApplicationResponse> OnOperate(SearchApplicationsRequest request)
    {
        var response = await _applicationRepository.ExecuteList(
            new SearchApplicationQuery(request),
            new PaginationQuery<ApplicationDao>(request)
        );
        
        return SearchApplicationResponse.FromData(response);
    }
}