namespace FinanceApp.Aplication.UseCases.RegisterCreditCard;

public record RegisterCreditCardCommand
{
    public Guid UserId { get; init; }
    public string Name { get; init; } = string.Empty;
};