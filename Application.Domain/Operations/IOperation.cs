namespace Application.Domain.Operations;

internal interface IOperation<in TRequest, TResponse>
{
    Task<TResponse> OnOperate(TRequest request);
}