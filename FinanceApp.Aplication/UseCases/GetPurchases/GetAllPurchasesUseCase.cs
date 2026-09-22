using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.GetPurchases;

public class GetAllPurchasesUseCase
{
    private readonly IPurchaseRepository _repository;

    public GetAllPurchasesUseCase(IPurchaseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PurchaseResponse>> ExecuteAsync()
    {
        var purchases = await _repository.GetAllAsync();

        return purchases.Select(p => new PurchaseResponse(
            p.Id,
            p.Description,
            p.Amount,
            p.CategoryId.ToString(),
            p.PurchaseId,
            p.CreatedAt

        ));
    }
}