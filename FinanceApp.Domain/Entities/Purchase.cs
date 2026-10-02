namespace FinanceApp.Domain.Entities;

public class Purchase
{
    public Guid Id { get; init; }
    public string Description { get; init ; }
    public decimal Amount { get; init ; }
    public Guid PurchaseId { get; init ; }
    public DateTimeOffset CreatedAt { get; init ; }
    public Guid? CreditCardId { get; init ; }
    public Guid CategoryId { get; init ; }
    protected Purchase() { }
    public Purchase(string description, decimal amount,Guid categoryId, Guid purchaserId, Guid? creditCardId = null)
    {
        if(amount < 1) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than or more zero.");
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        CategoryId = categoryId;
        PurchaseId = purchaserId;
        CreatedAt = DateTimeOffset.UtcNow;
        CreditCardId = creditCardId;

    }
}