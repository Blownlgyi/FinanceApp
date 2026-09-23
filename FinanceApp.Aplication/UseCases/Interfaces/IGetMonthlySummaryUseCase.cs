using FinanceApp.Aplication.UseCases.GetMonthlySummary;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface IGetMonthlySummaryUseCase
{
    Task<MonthlySummaryResult> ExecuteAsync(Guid userId, int year, int month);
}