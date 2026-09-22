using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories;

public interface IPurchaseRepository
{
    Task AddAsync(Purchase purchase);
    Task <IEnumerable<Purchase?>> GetAllAsync();
    Task <IEnumerable<Purchase?>> GetByUserIdAndMonthAsync (Guid userId, int year, int month);
    Task <IEnumerable<Purchase?>> GetInvoiceAsync(Guid creditCardId, int year , int month);
    
}