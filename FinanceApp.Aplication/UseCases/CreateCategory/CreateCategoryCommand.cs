using FinanceApp.Domain.Entities;

namespace FinanceApp.Aplication.UseCases.CreateCategory;

public record CreateCategoryRequest(Guid UserId, string Name);