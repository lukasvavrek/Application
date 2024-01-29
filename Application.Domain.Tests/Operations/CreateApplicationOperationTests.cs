using Application.Domain.Models;
using Application.Domain.Models.Dtos;
using Application.Domain.Operations.Create;
using Application.Domain.Repositories;
using NSubstitute;

namespace Application.Domain.Tests.Operations;

public class CreateApplicationOperationTests
{
    private CreateApplicationOperation _operation;

    private IDatabase _database;

    [SetUp]
    public void Setup()
    {
        _database = Substitute.For<IDatabase>();
        _operation = new CreateApplicationOperation(_database);
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldCreateNewApplication()
    {
        // Arrange
        const string title = "test_title";

        var request = CreateApplicationRequest.FromDto(new CreateApplicationDto
        {
            Title = title
        });
        
        // Act
        await _operation.OnOperate(request);
        
        // Assert
        await _database
            .Received()
            .AddAsync(Arg.Is<ApplicationDao>(dao => dao.Title == title));

        await _database
            .Received()
            .CommitAsync();
    }

    [Test]
    public async Task OnOperate_WhenCalled_ShouldReturnCorrectResponse()
    {
        // Arrange
        const int applicationId = 7;

        var request = CreateApplicationRequest.FromDto(new CreateApplicationDto
        {
            Title = "test-title"
        });

        await _database
            .AddAsync(Arg.Do<ApplicationDao>(dao => dao.Id = applicationId));
        
        // Act
        var response = await _operation.OnOperate(request);
        
        // Assert
        Assert.That(response.ApplicationId, Is.EqualTo(applicationId));
    }
}