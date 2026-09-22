namespace FinanceApp.Domain.Entities;

public class CreditCard
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name {get; private set;}
    
    protected CreditCard(){}

    public CreditCard(Guid userId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do cartão é obrigatório.");
        
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
    }
}