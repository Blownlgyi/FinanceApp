namespace FinanceApp.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    
    protected Category(){}

    public Category(Guid userId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be null or empty");

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
    }
}