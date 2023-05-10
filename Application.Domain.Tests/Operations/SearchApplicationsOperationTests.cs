using Application.Domain.Models;
using Application.Domain.Models.Dtos;
using Application.Domain.Operations.Search;
using Application.Domain.Queries;
using Application.Domain.Repositories;
using NSubstitute;

namespace Application.Domain.Tests.Operations;

public class SearchApplicationsOperationTests
{
    private SearchApplicationsOperation _operation;

    private IApplicationRepository _applicationRepository;
    
    [SetUp]
    public void Setup()
    {
        _applicationRepository = Substitute.For<IApplicationRepository>();
        _operation = new SearchApplicationsOperation(_applicationRepository);
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldApplyQueriesInCorrectOrder()
    {
        // Arrange
        var request = SearchApplicationsRequest.FromDto(new SearchApplicationsDto());
        
        // Act
        await _operation.OnOperate(request);
        
        // Assert
        await _applicationRepository
            .Received()
            .ExecuteList(Arg.Is<IQuery<ApplicationDao>[]>(queries =>
                queries.Length == 2 && 
                queries[0].GetType() == typeof(SearchApplicationQuery) &&
                queries[1].GetType() == typeof(PaginationQuery<ApplicationDao>)
            ));
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldReturnCorrectResponse()
    {
        // Arrange
        var request = SearchApplicationsRequest.FromDto(new SearchApplicationsDto());
        var result = new List<ApplicationDao>(Enumerable.Range(0, 10).Select(_ => new ApplicationDao()));

        _applicationRepository
            .ExecuteList(Arg.Any<IQuery<ApplicationDao>[]>())
            .Returns(result.AsEnumerable());
        
        // Act
        var response = await _operation.OnOperate(request);
        
        // Assert
        Assert.That(response.Applications.Count(), Is.EqualTo(result.Count));
    }
}