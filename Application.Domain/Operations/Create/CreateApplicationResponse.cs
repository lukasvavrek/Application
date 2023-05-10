namespace Application.Domain.Operations.Create;

public class CreateApplicationResponse
{
    public int ApplicationId { get; }

    private CreateApplicationResponse(int applicationId)
    {
        ApplicationId = applicationId;
    }

    public static CreateApplicationResponse FromId(int applicationId)
    {
        return new CreateApplicationResponse(applicationId);
    }
}