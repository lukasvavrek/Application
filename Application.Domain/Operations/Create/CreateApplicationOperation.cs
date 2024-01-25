using Application.Domain.Models;
using Application.Domain.Repositories;

namespace Application.Domain.Operations.Create;

internal class CreateApplicationOperation 
    : IOperation<CreateApplicationRequest, CreateApplicationResponse>
{
    private readonly IDatabase _database;

    public CreateApplicationOperation(IDatabase database)
    {
        _database = database;
    }
    
    public async Task<CreateApplicationResponse> OnOperate(CreateApplicationRequest request)
    {
        var dao = new ApplicationDao
        {
            Title = request.Title
        };

        await _database.AddAsync(dao);
        await _database.CommitAsync();

        return CreateApplicationResponse.FromId(dao.Id);
    }
}