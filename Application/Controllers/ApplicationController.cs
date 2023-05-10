using Application.Domain.Models.Dtos;
using Application.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ILogger<ApplicationController> _logger;
    private readonly IApplicationService _applicationService;

    public ApplicationController(
        ILogger<ApplicationController> logger,
        IApplicationService applicationService)
    {
        _logger = logger;
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<IEnumerable<ApplicationDto>> Get([FromQuery] SearchApplicationsDto dto)
    {
        return await _applicationService.GetAsync(dto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ApplicationDto> Get(int id)
    {
        return await _applicationService.GetAsync(id);
    }

    [HttpPost]
    public async Task<int> Create([FromBody] CreateApplicationDto dto)
    {
        _logger.LogDebug($">>> Creating application with title [{dto.Title}]");
        return await _applicationService.CreateAsync(dto);
    }
    
    [HttpDelete]
    public async Task Delete()
    {
        await _applicationService.DeleteAsync();
    }
}