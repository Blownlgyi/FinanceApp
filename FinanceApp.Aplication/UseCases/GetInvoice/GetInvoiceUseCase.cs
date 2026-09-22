using FinanceApp.Domain.Repositories;
using FinanceApp.Aplication.UseCases.GetPurchases;
namespace FinanceApp.Aplication.UseCases.GetInvoice;

public class GetInvoiceUseCase
{
    private readonly IPurchaseRepository _purchaseRepository;

    public GetInvoiceUseCase(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<InvoiceResult> ExecuteAsync(Guid creditCardId, int year, int month)
    {
        var purchases = await _purchaseRepository.GetInvoiceAsync(creditCardId, year, month);
        var totalAmount = purchases.Sum(p => p.Amount);
        
        var purchaseResponses = purchases.Select(p => new PurchaseResponse(
            p.Id,
            p.Description,
            p.Amount,
            p.CategoryId.ToString(),
            p.PurchaseId,
            p.CreatedAt
            ) );
        
        return new InvoiceResult(creditCardId, year, month, totalAmount, purchaseResponses);
    }
}