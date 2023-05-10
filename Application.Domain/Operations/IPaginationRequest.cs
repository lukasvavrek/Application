namespace Application.Domain.Operations;

public interface IPaginationRequest
{
    public int Skip { get; }
    public int Take { get; }
}