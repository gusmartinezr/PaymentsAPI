using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities;

public class Payment
{
    public Guid PaymentId { get; private set; }
    public Guid CustomerId { get; private set; }
    public string ServiceProvider { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = string.Empty;
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Payment() { }

    public Payment(Guid customerId, string serviceProvider, decimal amount, string currency)
    {
        PaymentId = Guid.NewGuid();
        CustomerId = customerId;
        ServiceProvider = serviceProvider;
        Amount = amount;
        Currency = string.IsNullOrWhiteSpace(currency) ? PaymentCurrencies.Boliviano : currency;
        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }
}