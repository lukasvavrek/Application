using Application.Domain.Models.Dtos;

namespace Application.Domain.Operations.Search;

public class SearchApplicationsRequest : IPaginationRequest
{
    public int Skip => 0;
    public int Take => 10;
    
    public string TitleStartsWith { get; }
    
    // Search parameters and filters will go here
    private SearchApplicationsRequest(string titleStartsWith)
    {
        TitleStartsWith = titleStartsWith;
    }

    public static SearchApplicationsRequest FromDto(SearchApplicationsDto dto)
    {
        return new SearchApplicationsRequest(dto.TitleStartsWith);
    }
}