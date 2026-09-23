using FinanceApp.Aplication.UseCases.GetMonthlySummary;
using FinanceApp.Aplication.UseCases.SetSalary;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinanceController : ControllerBase
{
    [HttpPost("salary")]
    [Consumes("application/json")]
    public async Task<IActionResult> SetSalary(
        [FromBody] SetSalaryResquest resquest,
        [FromServices] SetSalaryUseCase useCase
    )
    {
        await useCase.ExecuteAsync(resquest);
        return Ok();
    }

    [HttpGet("summary/{userId}/{year}/{month}")]

    public async Task<IActionResult> GetSummary(
        [FromRoute] Guid userId, 
        [FromRoute] int year, 
        [FromRoute] int month, 
        [FromServices] GetMonthlySummaryUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(userId, year, month);
        return Ok(result);
    }
    
    
}