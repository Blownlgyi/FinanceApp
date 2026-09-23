using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.GetExpensesByCategory;

public class GetExpensesByCategoryUseCase
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetExpensesByCategoryUseCase(IPurchaseRepository purchaseRepository, ICategoryRepository categoryRepository)
    {
        _purchaseRepository = purchaseRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryExpenseResult?>> ExecuteAsync(Guid userId, int year, int month)
    {
        var purchasesTask = _purchaseRepository.GetByUserIdAndMonthAsync(userId, year, month);
        var categoriesTask = _categoryRepository.GetByUserIdAsync(userId);

        await Task.WhenAll(purchasesTask, categoriesTask);

        var purchases = purchasesTask.Result;
        var categories = categoriesTask.Result;

        var result = purchases
            .GroupBy(p => p.CategoryId)
            .Select(group =>
                new CategoryExpenseResult(
                    CategoryName: categories.FirstOrDefault(c => c.Id == group.Key)?.Name ?? "Categoria Removida",
                    TotalAmount: group.Sum(p => p.Amount)
                )).OrderByDescending(r => r.TotalAmount);

        return result;
    }
}