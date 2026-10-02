using FinanceApp.Aplication.UseCases.GetPurchases;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface IGetAllPurchasesUseCase
{
    Task<IEnumerable<PurchaseResponse>> ExecuteAsync();
}