using Application.Domain.Models;
using Application.Domain.Repositories;

namespace Application.Domain.Operations.Create;

internal class CreateApplicationOperation 
    : IOperation<CreateApplicationRequest, CreateApplicationResponse>
{
    private readonly IApplicationRepository _applicationRepository;

    public CreateApplicationOperation(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task<CreateApplicationResponse> OnOperate(CreateApplicationRequest request)
    {
        var dao = new ApplicationDao
        {
            Title = request.Title
        };

        await _applicationRepository.Add(dao);
        await _applicationRepository.SaveChangesAsync();

        return CreateApplicationResponse.FromId(dao.Id);
    }
}