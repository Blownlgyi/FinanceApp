using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Repositories;

public interface ICreditCardRepository
{
    Task AddAsync (CreditCard creditCard);
    Task <IEnumerable<CreditCard>> GetByUserIdAsync (Guid userId);
}