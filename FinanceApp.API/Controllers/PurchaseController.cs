using FinanceApp.Aplication.UseCases.RegisterPurchase;
using FinanceApp.Aplication.UseCases.GetPurchases;
using Microsoft.AspNetCore.Mvc;


namespace FinanceApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly RegisterPurchaseUseCase _useCase;

    public PurchaseController(RegisterPurchaseUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Register([FromBody] RegisterPurchaseRequest command)
    {
        await _useCase.ExecuteAsync(command);
        return StatusCode(201);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] GetAllPurchasesUseCase getUseCase)
    {
        var result = await getUseCase.ExecuteAsync();
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}