using FinanceApp.Aplication.UseCases.GetCreditCards;
using FinanceApp.Aplication.UseCases.GetInvoice;
using FinanceApp.Aplication.UseCases.RegisterCreditCard;
using FinanceApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    [HttpPost]
    [Consumes("application/json")]
    public async Task<ActionResult<CreditCard>> Register([FromBody] RegisterCreditCardRequest command,[FromServices] RegisterCreditCardUseCase useCase)
    {
        await useCase.ExecuteAsync(command);
        return StatusCode(201);
    }
  
    [HttpGet("{creditCard}/invoice/{year}/{month}")]
    public async Task<IActionResult> GetInvoice(
        [FromRoute] Guid creditCard,
        [FromRoute] int year,
        [FromRoute] int month,
        [FromServices] GetInvoiceUseCase useCase
    )
    {
        var result = await useCase.ExecuteAsync(creditCard, year, month);
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser([FromRoute] Guid userId, [FromServices] GetCreditCardsUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(userId);
        return Ok(result);
    }
}