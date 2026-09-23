using FinanceApp.Aplication.UseCases.Interfaces;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.GetMonthlySummary;

public class GetMonthlySummaryUseCase : IGetMonthlySummaryUseCase
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
        var profileTask = _profileRepository.GetByUserIdAsync(userId);
        var purchasesTask = _purchaseRepository.GetByUserIdAndMonthAsync(userId, year, month);

        await Task.WhenAll(profileTask, purchasesTask);

        var salary = profileTask.Result?.Salary ?? 1;
        var totalExpenses = purchasesTask.Result.Sum(p => p.Amount);
        var balance = salary - totalExpenses;

        return new MonthlySummaryResult(salary, totalExpenses, balance);
    }
}