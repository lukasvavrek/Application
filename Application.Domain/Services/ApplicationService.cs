using Application.Domain.Models.Dtos;
using Application.Domain.Operations.Create;
using Application.Domain.Operations.Search;

namespace Application.Domain.Services;

internal class ApplicationService : BaseService, IApplicationService
{
    public ApplicationService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }
    
    public async Task<IEnumerable<ApplicationDto>> GetAsync(SearchApplicationsDto dto)
    {
        var request = SearchApplicationsRequest.FromDto(dto);
        var operation = Get<SearchApplicationsOperation>();
        var response = await operation.OnOperate(request);

        return response.Applications;
    }

    public Task<ApplicationDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(CreateApplicationDto dto)
    {
        var request = CreateApplicationRequest.FromDto(dto);
        var operation = Get<CreateApplicationOperation>();
        var response = await operation.OnOperate(request);

        return response.ApplicationId;
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
}