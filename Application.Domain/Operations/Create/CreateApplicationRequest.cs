using Application.Domain.Models.Dtos;

namespace Application.Domain.Operations.Create;

public class CreateApplicationRequest
{
    public string Title { get; }

    private CreateApplicationRequest(string title)
    {
        Title = title;
    }

    public static CreateApplicationRequest FromDto(CreateApplicationDto dto)
    {
        return new CreateApplicationRequest(dto.Title);
    }
}