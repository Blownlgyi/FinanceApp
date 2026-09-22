using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.RegisterPurchase;

public class RegisterPurchaseUseCase
{
    private readonly IPurchaseRepository _repository;
    public RegisterPurchaseUseCase(IPurchaseRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(RegisterPurchaseRequest command)
    {
        try
        {
            var purchase = new Purchase(
            command.Description, 
            command.Amount, 
            command.CategoryId, 
            command.PurchaserId,
            command.CreditCardId
                                         );
            await _repository.AddAsync(purchase);
        

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}