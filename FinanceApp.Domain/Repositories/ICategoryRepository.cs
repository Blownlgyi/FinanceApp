using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories;

public interface ICategoryRepository
{
    Task AddAsync (Category category);
    Task <IEnumerable<Category>> GetByUserIdAsync(Guid userId);
}