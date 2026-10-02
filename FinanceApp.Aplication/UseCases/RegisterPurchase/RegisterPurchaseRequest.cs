
namespace FinanceApp.Aplication.UseCases.RegisterPurchase;

public record RegisterPurchaseRequest
{
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public Guid CategoryId { get; init; }
    public Guid PurchaserId { get; init; }
    public Guid? CreditCardId { get; init; }
}