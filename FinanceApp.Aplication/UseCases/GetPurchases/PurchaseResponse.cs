namespace FinanceApp.Aplication.UseCases.GetPurchases;

public record PurchaseResponse(
    Guid Id, 
    string Description, 
    decimal Amount, 
    string CategoryId, 
    Guid PurchaserId, 
    DateTimeOffset CreatedAt
    );