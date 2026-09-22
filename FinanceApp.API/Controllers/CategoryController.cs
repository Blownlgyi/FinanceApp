using FinanceApp.Aplication.UseCases.CreateCategory;
using FinanceApp.Aplication.UseCases.GetExpensesByCategory;
using FinanceApp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryCommand command,
        [FromServices] CreateCategoryUseCase useCase)
    {
        await useCase.ExecuteAsync(command);
        return Ok();
    }

    [HttpGet("expenses/{userId}/{year}/{month}")]
    public async Task<IActionResult> GetExpensesByCategory(
        [FromRoute] Guid userId,
        [FromRoute] int year,
        [FromRoute] int month,
        [FromServices] GetExpensesByCategoryUseCase useCase

    )
    {
        var result = await useCase.ExecuteAsync(userId, year, month);
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(
        [FromRoute] Guid userId,
        [FromServices] ICategoryRepository repository)
    {
        var categories = await repository.GetByUserIdAsync(userId);
        return Ok(categories.Select(c=> new {c.Id, c.Name}));
    }
}