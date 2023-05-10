using Application.Domain.Models.Dtos;

namespace Application.Domain.Operations.Search;

public class SearchApplicationResponse
{  
    public IEnumerable<ApplicationDto> Applications { get; }
    
    private SearchApplicationResponse(IEnumerable<ApplicationDto> applications)
    {
        Applications = applications;
    }

    public static SearchApplicationResponse FromData(IEnumerable<Models.ApplicationDao> applications)
    {
        var dtos = applications.Select(m => new ApplicationDto
        {
            Id = m.Id,
            Title = m.Title,
        });
        
        return new SearchApplicationResponse(dtos);
    }
}