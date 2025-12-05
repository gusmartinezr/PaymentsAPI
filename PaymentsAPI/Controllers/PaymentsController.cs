using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Services;
using Application.DTOs.Generic;
using FluentValidation;

namespace PaymentsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<PaymentResponse>>> Create(
        [FromBody] CreatePaymentRequest request)
    {
        var response = new ApiResponse<PaymentResponse>();

        try
        {
            var result = await _paymentService.CreateAsync(request);

            response.IsSuccess = true;
            response.Data = result;
            response.DisplayMessage = "Payment created successfully";

            return Ok(response);
        }
        catch (ValidationException ex)
        {
            response.IsSuccess = false;
            response.Data = null;
            response.DisplayMessage = "There was an error creating the payment";

            response.ErrorMessages = ex.Errors
                .Select(e => e.PropertyName + ": " + e.ErrorMessage)
                .ToList();

            return BadRequest(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Data = null;
            response.DisplayMessage = "There was an unexpected error";
            response.ErrorMessages = new() { ex.Message };

            return StatusCode(500, response);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<PaymentResponse>>>> GetByCustomer(
        [FromQuery] Guid customerId)
    {
        var response = new ApiResponse<List<PaymentResponse>>();

        try
        {
            if (customerId == Guid.Empty)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.DisplayMessage = "Invalid customer ID";
                response.ErrorMessages = new() { "CustomerId cannot be empty." };
                return BadRequest(response);
            }

            var result = await _paymentService.GetByCustomerAsync(customerId);

            response.IsSuccess = true;
            response.Data = result.ToList();
            response.DisplayMessage = "Payments retrieved successfully";

            return Ok(response);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Data = null;
            response.DisplayMessage = "There was an unexpected error";
            response.ErrorMessages = new() { ex.Message };

            return StatusCode(500, response);
        }
    }
}
