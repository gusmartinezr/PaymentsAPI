using FluentValidation;
using Application.DTOs.Requests;
using Domain.Constants;

namespace Application.DTOs.Validators;

public class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentRequestValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("El CustomerId es obligatorio.");

        RuleFor(x => x.ServiceProvider)
            .NotEmpty().WithMessage("El proveedor es obligatorio.")
            .MaximumLength(200).WithMessage("El proveedor no puede exceder 200 caracteres.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.")
            .LessThanOrEqualTo(1500).WithMessage("El monto no puede exceder los 1500 Bs.");

        RuleFor(x => x.Currency)
            .Must(BeAllowedCurrency) 
            .WithMessage("La moneda debe ser 'BOB'. No se aceptan pagos en Dólares ('USD').");  
    }

    private bool BeAllowedCurrency(string? currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            return true; 

        var input = currency.Trim().ToUpperInvariant();

        return input == PaymentCurrencies.Boliviano; 
    }
}