using Application.Domain.Models;
using Application.Domain.Models.Dtos;
using Application.Domain.Operations.Create;
using Application.Domain.Repositories;
using NSubstitute;

namespace Application.Domain.Tests.Operations;

public class CreateApplicationOperationTests
{
    private CreateApplicationOperation _operation;

    private IApplicationRepository _applicationRepository;

    [SetUp]
    public void Setup()
    {
        _applicationRepository = Substitute.For<IApplicationRepository>();
        _operation = new CreateApplicationOperation(_applicationRepository);
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
        await _applicationRepository
            .Received()
            .Add(Arg.Is<ApplicationDao>(dao => dao.Title == title));

        await _applicationRepository
            .Received()
            .SaveChangesAsync();
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

        await _applicationRepository
            .Add(Arg.Do<ApplicationDao>(dao => dao.Id = applicationId));
        
        // Act
        var response = await _operation.OnOperate(request);
        
        // Assert
        Assert.That(response.ApplicationId, Is.EqualTo(applicationId));
    }
}