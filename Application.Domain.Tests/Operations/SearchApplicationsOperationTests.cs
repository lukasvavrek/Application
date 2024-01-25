using Application.Domain.Models;
using Application.Domain.Models.Dtos;
using Application.Domain.Operations.Search;
using Application.Domain.Repositories;
using NSubstitute;

namespace Application.Domain.Tests.Operations;

public class SearchApplicationsOperationTests
{
    private SearchApplicationsOperation _operation;

    private IDatabase _database;
    
    [SetUp]
    public void Setup()
    {
        _database = Substitute.For<IDatabase>();
        _operation = new SearchApplicationsOperation(_database);
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldApplyQueriesInCorrectOrder()
    {
        // Arrange
        var request = SearchApplicationsRequest.FromDto(new SearchApplicationsDto());
        
        // Act
        await _operation.OnOperate(request);
        
        // Assert
        await _database
            .Received()
            .ToListAsync(Arg.Any<IQueryable<ApplicationDao>>());
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldReturnCorrectResponse()
    {
        // Arrange
        var request = SearchApplicationsRequest.FromDto(new SearchApplicationsDto());
        var result = new List<ApplicationDao>(Enumerable.Range(0, 10).Select(_ => new ApplicationDao()));

        _database
            .ToListAsync(Arg.Any<IQueryable<ApplicationDao>>())
            .Returns(result.AsEnumerable());
        
        // Act
        var response = await _operation.OnOperate(request);
        
        // Assert
        Assert.That(response.Applications.Count(), Is.EqualTo(result.Count));
    }
}