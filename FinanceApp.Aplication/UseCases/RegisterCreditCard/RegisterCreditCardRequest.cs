namespace FinanceApp.Aplication.UseCases.RegisterCreditCard;

public record RegisterCreditCardRequest
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = string.Empty;
};