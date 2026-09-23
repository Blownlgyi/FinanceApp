using FinanceApp.Aplication.UseCases.RegisterPurchase;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface IRegisterPurchaseUse
{
    Task ExecuteAsync(RegisterPurchaseRequest request);
}