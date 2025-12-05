namespace Application.DTOs.Responses;

public class PaymentResponse
{
    public Guid PaymentId { get; set; }
    public string ServiceProvider { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}