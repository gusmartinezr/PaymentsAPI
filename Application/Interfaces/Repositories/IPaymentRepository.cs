using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment, CancellationToken cancellationToken = default);
    Task<List<Payment>> GetByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default);
}