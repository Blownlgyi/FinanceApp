using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories;

public interface IFinancialProfileRepository
{
    Task<FinancialProfile?> GetByUserIdAsync(Guid userId);
    Task SaveAsync(FinancialProfile profile);
    Task UpdateAsync(FinancialProfile profile);
}