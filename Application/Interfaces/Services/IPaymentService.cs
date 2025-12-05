using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services;

public interface IPaymentService
{
    Task<PaymentResponse> CreateAsync(
        CreatePaymentRequest request,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<PaymentResponse>> GetByCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);
}