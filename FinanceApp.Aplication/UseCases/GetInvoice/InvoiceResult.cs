using FinanceApp.Aplication.UseCases.GetPurchases;

namespace FinanceApp.Aplication.UseCases.GetInvoice;

public record InvoiceResult(
    Guid CreditCardId,
    int Year,
    int Month,
    decimal TotalAmount,
    IEnumerable<PurchaseResponse> Purchases);