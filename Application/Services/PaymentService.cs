using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Mapping;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IValidator<CreatePaymentRequest> _validator;

    public PaymentService(
        IPaymentRepository paymentRepository, 
        IValidator<CreatePaymentRequest> validator)
    {
        _paymentRepository = paymentRepository;
        _validator = validator;
    }

    public async Task<PaymentResponse> CreateAsync(CreatePaymentRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var payment = new Payment(
            request.CustomerId,
            request.ServiceProvider,
            request.Amount,
            request.Currency
        );


        await _paymentRepository.AddAsync(payment); 

        return payment.ToResponse();
    }

    public async Task<IReadOnlyList<PaymentResponse>> GetByCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        var payments = await _paymentRepository.GetByCustomerAsync(customerId);

        return payments.ToResponseList();
    }
}