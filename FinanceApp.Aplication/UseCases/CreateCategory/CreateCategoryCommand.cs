using FinanceApp.Domain.Entities;

namespace FinanceApp.Aplication.UseCases.CreateCategory;

public record CreateCategoryCommand(Guid UserId, string Name);