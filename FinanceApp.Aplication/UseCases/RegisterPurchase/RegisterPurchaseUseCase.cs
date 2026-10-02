using FinanceApp.Aplication.UseCases.Interfaces;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.RegisterPurchase;

public class RegisterPurchaseUseCase : IRegisterPurchaseUse
{
    private readonly IPurchaseRepository _repository;
    public RegisterPurchaseUseCase(IPurchaseRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(RegisterPurchaseRequest request)
    {
       
            var purchase = new Purchase(
            request.Description, 
            request.Amount, 
            request.CategoryId, 
            request.PurchaserId,
            request.CreditCardId
                                         );
            await _repository.AddAsync(purchase);
        
        

    }
}