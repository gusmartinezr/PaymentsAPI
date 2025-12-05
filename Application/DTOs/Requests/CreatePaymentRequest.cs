namespace Application.DTOs.Requests;

public class CreatePaymentRequest
{
    public Guid CustomerId { get; set; }
    public string ServiceProvider { get; set; } = null!;
    public decimal Amount { get; set; }
    public string? Currency { get; set; } 
}