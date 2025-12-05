using Application.DTOs.Responses;
using Domain.Entities;

namespace Application.Mapping;

public static class PaymentMapping
{
    public static PaymentResponse ToResponse(this Payment payment)
    {
        return new PaymentResponse
        {
            PaymentId = payment.PaymentId,
            ServiceProvider = payment.ServiceProvider,
            Amount = payment.Amount,
            Status = payment.Status.ToString().ToLowerInvariant(),
            CreatedAt = payment.CreatedAt
        };
    }

    public static IReadOnlyList<PaymentResponse> ToResponseList(this IEnumerable<Payment> payments)
    {
        return payments
            .Select(p => p.ToResponse())
            .ToList();
    }
}