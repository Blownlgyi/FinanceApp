using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.GetMonthlySummary;

public class GetMonthlySummaryUseCase
{
    private readonly IFinancialProfileRepository _profileRepository;
    private readonly IPurchaseRepository _purchaseRepository;

    public GetMonthlySummaryUseCase (IFinancialProfileRepository profileRepository, IPurchaseRepository purchaseRepository)
    {
        _profileRepository = profileRepository;
        _purchaseRepository = purchaseRepository;
    }

    public async Task<MonthlySummaryResult> ExecuteAsync(Guid userId, int year, int month)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userId);
        var salary = profile?.Salary ?? 1;

        var purchases = await _purchaseRepository.GetByUserIdAndMonthAsync(userId, year, month);
        var totalExpenses = purchases.Sum(p => p.Amount);
        var balance = salary - totalExpenses;

        return new MonthlySummaryResult(salary, totalExpenses, balance);
    }
}