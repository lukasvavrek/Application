using Application.Domain.Models.Dtos;

namespace Application.Domain.Services;

public interface IApplicationService
{
    public Task<IEnumerable<ApplicationDto>> GetAsync(SearchApplicationsDto dto);
    public Task<ApplicationDto> GetAsync(int id);
    public Task<int> CreateAsync(CreateApplicationDto dto);
    public Task DeleteAsync();
}